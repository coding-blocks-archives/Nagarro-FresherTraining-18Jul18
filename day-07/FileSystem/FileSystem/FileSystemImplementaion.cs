using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemImplementation
{
    abstract class Entity
    {
        protected string name;
        protected int size;
        protected DateTime createdAt;
        protected DateTime lastUpdatedAt;
        protected DateTime lastAccessedAt;
        protected Directory parent;
        abstract public int GetSize();

        protected Entity(string name)
        {
            this.name = name;
            createdAt = DateTime.Now;
            lastUpdatedAt = DateTime.Now;
            lastAccessedAt = DateTime.Now;
            parent = null;
        }

        public DateTime GetCreatedAt()
        {
            return createdAt;
        }
        public DateTime GetLastUpdatedAt()
        {
            return lastUpdatedAt;
        }

        public DateTime GetLastAccessAt()
        {
            return lastAccessedAt;
        }
        
        protected void SetLastAccess()
        {
            lastAccessedAt = DateTime.Now;
        }

        protected void SetLastUpdate()
        {
            lastUpdatedAt = DateTime.Now;
        }

        // TODO Debug this 
        abstract public void DeleteEntity();
    }

    class File : Entity
    {
        string contents;

        public File(string name, Directory parent, int size):base(name)
        {
            this.size = size;
            this.parent = parent;
        }

        string GetContents()
        {
            return contents;
        }

        void SetContents(string contents, int newSize)
        {
            this.contents = contents;
            this.size = newSize;
        }

        public override int GetSize()
        {
            return size;       
        }

        public override void DeleteEntity()
        {
            parent.RemoveFrmParent(this);
        }
    }
    
    class Directory : Entity
    {
        LinkedList<Entity> dirContents;
        
        public Directory(string name, Directory parent) : base(name)
        {
            dirContents = new LinkedList<Entity>();
            this.parent = parent;
        }

        public override int GetSize()
        {
            size = 0;
            foreach (Entity e in dirContents)
            {
                // TODO 
                size += e.GetSize();
            }
            return size;
        }

        void AddEntity(Entity e)
        {
            dirContents.AddLast(e);
        }

        public override void DeleteEntity()
        {
            parent.RemoveFrmParent(this);
        }

        // SAME ASSEMBLY.
        internal void RemoveFrmParent(Entity e)
        {
            dirContents.Remove(e);    
        }
        
        // TODO return a read only reference
        // main SHOULD NOT update dirContents
        LinkedList<Entity> GetEntites()
        {
            return dirContents;
        }
    }
}
