using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;

namespace Win8Helper
{
    public static class StorageFolderExtensions
    {

        /// <summary> 
        /// StorageFolder 扩展方法，判断文件是否存在 
        /// </summary> 
        /// <param name="folder"></param> 
        /// <param name="fileName"></param> 
        /// <returns></returns> 
        internal static async Task<bool> CheckFileExisted(this StorageFolder folder, string fileName)
        {
            return folder != null &&
                   (await (
                              folder.CreateFileQueryWithOptions(
                                  new QueryOptions
                                  {
                                      FolderDepth = FolderDepth.Shallow,
                                      UserSearchFilter = "System.FileName:\"" + fileName + "\""
                                  })).GetFilesAsync()).Count > 0
                       ? true
                       : false;
        }


    }
}
