﻿using JetBrains.Annotations;
using NetLib;
using NLog;
using System;
using System.IO;
using AcadLib.UI.Ribbon.Options;

namespace AcadLib.IO
{
    /// <summary>
    /// Данные хранимые в файле json на сервере, с локальным кэшем
    /// </summary>
    public class JsonData<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static ILogger Logger { get; } = LogManager.GetCurrentClassLogger();
        // ReSharper disable once MemberCanBePrivate.Global
        public readonly string ServerFile;
        // ReSharper disable once MemberCanBePrivate.Global
        public readonly string LocalFile;

        /// <summary>
        /// Данные хранимые в файле json на сервере, с локальным кэшем
        /// </summary>
        /// <param name="plugin">Имя плагина</param>
        /// <param name="name">Имя файла - без расширения (всегда .json)</param>
        public JsonData([NotNull] string plugin, [NotNull] string name)
        {
            ServerFile = Path.GetSharedFile(plugin, name + ".json");
            LocalFile = Path.GetUserPluginFile(plugin, name + ".json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="IOException"/>
        [CanBeNull]
        // ReSharper disable once MemberCanBePrivate.Global
        public T Load()
        {
            Copy();
            return !File.Exists(LocalFile) ? default : LocalFile.Deserialize<T>();
        }

        [CanBeNull]
        public T TryLoad()
        {
            try
            {
                return Load();
            }
            catch
            {
                return default;
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void Save(T data)
        {
            data.Serialize(ServerFile);
            Copy();
        }

        public void TrySave(T data)
        {
            try
            {
                Save(data);
            }
            catch
            {
                //
            }
        }

        private void Copy()
        {
            if (!File.Exists(ServerFile)) return;
            try
            {
                File.Copy(ServerFile, LocalFile, true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "JsonData копирование файла с сервера локально.");
            }
        }
    }
}