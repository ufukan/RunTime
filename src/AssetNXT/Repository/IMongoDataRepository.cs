﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AssetNXT.Models;

namespace AssetNXT.Repository
{
    public interface IMongoDataRepository<TDocument>
    where TDocument : IDocument
    {
        List<TDocument> GetAll();

        Task<List<TDocument>> GetAllAsync();

        List<TDocument> GetAllLatest();

        Task<List<TDocument>> GetAllLatestAsync();

        TDocument GetObjectById(string id);

        Task<TDocument> GetObjectByIdAsync(string id);

        TDocument GetObjectByDeviceId(string id);

        Task<TDocument> GetObjectByDeviceIdAsync(string id);

        List<TDocument> GetAllObjectsByDeviceId(string id);

        Task<List<TDocument>> GetAllObjectsByDeviceIdAsync(string id);

        void CreateObject(TDocument document);

        Task CreateObjectAsync(TDocument document);

        void UpdateObject(string id, TDocument document);

        Task UpdateObjectAsync(string id, TDocument document);

        void RemoveObject(TDocument document);

        Task RemoveObjectAsync(TDocument document);

        void RemoveObjectById(string id);

        Task RemoveObjectByIdAsync(string id);
    }
}
