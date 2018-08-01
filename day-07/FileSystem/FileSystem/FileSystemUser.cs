using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemImplementation;
namespace FileSystemUser
{
    class FileSytemUsrMain
    {
        public static void main()
        {
            FileSystemImplementation.Directory c = new Directory("C:", null);
            Directory d = new Directory("D:", null);

            Directory movies = new Directory("Movies", d);
            File antmanWasp = new File("AntmanWasp", movies, 1024 * 1024);

            antmanWasp.DeleteEntity();  // deletes a file
            movies.DeleteEntity();  // deletes a dir

        }
    }
}
