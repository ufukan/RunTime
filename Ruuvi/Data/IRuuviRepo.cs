using System.Collections.Generic;
using Ruuvi.Models;

namespace  Ruuvi.Data
{
    // Here we are going to define the CRUD operations
    public interface IRuuviRepo
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
    }
}