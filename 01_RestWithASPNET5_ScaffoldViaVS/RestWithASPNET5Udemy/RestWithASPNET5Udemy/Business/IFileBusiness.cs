using Microsoft.AspNetCore.Http;
using RestWithASPNET5Udemy.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);

        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);

        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);


    }
}
