using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Trees
{
    public class DSU
    {
        private int[] _parent;
        private int[] _rank;

        public DSU(int n)
        {
            _parent = new int[n];
            _rank = new int[n];
        }

        public void MakeSet(int key)
        {
            _parent[key] = key;
        }

        public int Find(int key)
        {
            int root = key;

            while (root != _parent[root])
                root = _parent[root];

            while (key != _parent[key])
            {
                int next = _parent[key];
                _parent[key] = root;
                key = next;
            }
            return root;

            //Рекурсивная версия
            //if (_parent[key] == key)
            //    return key;

            //return _parent[key] = Find(_parent[key]);
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY) return;

            if (_rank[rootX] > _rank[rootY])
            {
                _parent[rootY] = rootX;
            }
            else if(_rank[rootX] < _rank[rootY])
            {
                _parent[rootX] = rootY;
            }
            else
            {
                _parent[rootY] = rootX;
                _rank[rootX]++;
            }                   
        }
    }
}
