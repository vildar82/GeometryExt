﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadLib.Errors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AcadLib.Blocks.Dublicate
{
   /// <summary>
   /// Проверка наложения блоков в пространстве модели
   /// </summary>
   public static class CheckDublicateBlocks
   {
      public static Tolerance Tolerance { get; set; } = new Tolerance(0.02, 10);
      public static int DEPTH = 5;
      private static int curDepth;
      private static HashSet<ObjectId> attemptedblocks;
      private static List<BlockRefDublicateInfo> AllDublicBlRefInfos;

      public static void Check()
      {
         curDepth = 0;
         Database db = HostApplicationServices.WorkingDatabase;
         Inspector.Clear();
         attemptedblocks = new HashSet<ObjectId>();
         AllDublicBlRefInfos = new List<BlockRefDublicateInfo>();
         try
         {
            GetDublicateBlocks(SymbolUtilityServices.GetBlockModelSpaceId(db), Matrix3d.Identity);
         }
         catch (Exception ex)
         {
            AutoCAD_PIK_Manager.Log.Error(ex, $"CheckDublicateBlocks - {db.Filename}");
            return;
         }
         
         foreach (var dublBlRefInfo in AllDublicBlRefInfos)
         {
            Inspector.AddError($"Дублирование блоков '{dublBlRefInfo.Name}' - {dublBlRefInfo.CountDublic} шт. в точке {dublBlRefInfo.Position.ToString()}",
               dublBlRefInfo.IdBlRef, dublBlRefInfo.TransformToModel, System.Drawing.SystemIcons.Error);
         }

         if (Inspector.HasErrors)
         {
            if (Inspector.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
               Inspector.Show();
               throw new Exception("Отменено пользователем.");
            }
         }
      }

      private static void GetDublicateBlocks(ObjectId idBtr, Matrix3d transToModel)
      {         
         // Проверялся ли уже такое определение блока
         if (attemptedblocks.Add(idBtr))
         {
            // такой блок еще не проверялся. Перебор его объетов
            List<Tuple<ObjectId, Matrix3d>> idsBtrNext = new List<Tuple<ObjectId, Matrix3d>>();
            List<BlockRefDublicateInfo> blrefInfos = new List<BlockRefDublicateInfo>();
            using (var btr = idBtr.Open(OpenMode.ForRead) as BlockTableRecord)
            {
               // Получение всех вхождений блоков               
               foreach (var idEnt in btr)
               {
                  using (var blRef = idEnt.Open(OpenMode.ForRead, false, true) as BlockReference)
                  {
                     if (blRef == null) continue;
                     BlockRefDublicateInfo blRefInfo = new BlockRefDublicateInfo(blRef);
                     blrefInfos.Add(blRefInfo);

                     idsBtrNext.Add(new Tuple<ObjectId, Matrix3d>(item1: blRef.BlockTableRecord, item2: transToModel * blRef.BlockTransform));
                  }
               }
            }
            // дублирующиеся блоки
            var dublicBlRefInfos = blrefInfos.GroupBy(g => g).Where(b => b.Count() > 1)
                                       .Select(s =>
                                       {
                                          var bi = s.First();
                                          bi.CountDublic = s.Count();
                                          return bi;
                                       }).ToList();            

            // Добавление дубликатов в результирующий список
            AddTransformedToModelDublic(transToModel, dublicBlRefInfos);

            // Нырок глубже
            if (curDepth < DEPTH)
            {
               curDepth++;
               foreach (var btrNext in idsBtrNext)
               {
                  GetDublicateBlocks(btrNext.Item1, btrNext.Item2);
               }               
            }
         }
      }

      private static void AddTransformedToModelDublic(Matrix3d transToModel, List<BlockRefDublicateInfo> dublicBlRefInfos)
      {
         // Трансформированные копии инфоблоков и добавление в результирующий список дубликатов
         var trancDublicBlRefInfos = dublicBlRefInfos.Select(b => b.TransCopy(transToModel)).ToList();
         AllDublicBlRefInfos.AddRange(trancDublicBlRefInfos);
      }
   }   
}