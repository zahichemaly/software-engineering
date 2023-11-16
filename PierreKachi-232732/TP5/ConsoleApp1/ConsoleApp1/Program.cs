namespace Arbre
{
    public class ArbreRecherche
    {
        private class Noeud
        {
            public int valeur;
            public Noeud? fg, fd;
        }
        private Noeud? racine;
        public ArbreRecherche()
        {
            racine = null;
        }
        public void add(int x)
        {

            racine = addRec(racine, x);
        }
        private Noeud addRec(Noeud root, int x)
        {
            if (root == null)
            {
                root = new Noeud();
                root.valeur = x;
                return root;
            }

            if (x < root.valeur)
                root.fg = addRec(root.fg, x);
            else if (x > root.valeur)
                root.fd = addRec(root.fd, x);

            return root;
        }
        public bool find(int x)
        {
            return findRec(racine, x);

        }
        private bool findRec(Noeud root, int x)
        {
            if (root == null)
                return false;

            if (x == root.valeur)
                return true;

            if (x < root.valeur)
                return findRec(root.fg, x);

            return findRec(root.fd, x);
        }
        public int depth()
        {
            return depthRec(racine);
        }

        private int depthRec(Noeud root)
        {
            if (root == null)
                return -1;

            int leftDepth = depthRec(root.fg);
            int rightDepth = depthRec(root.fd);

            return 1 + Math.Max(leftDepth, rightDepth);
        }
        public int size()
        {
            return sizeRec(racine);
        }

        private int sizeRec(Noeud root)
        {
            if (root == null)
                return 0;

            return 1 + sizeRec(root.fg) + sizeRec(root.fd);
        }
        public int[] rangerEnordre()
        {
            List<int> list = new List<int>();
            rangerEnordreRec(racine, list);
            return list.ToArray();
        }
        private void rangerEnordreRec(Noeud root, List<int> list)
        {
            if (root != null)
            {
                rangerEnordreRec(root.fg, list);
                list.Add(root.valeur);
                rangerEnordreRec(root.fd, list);
            }
        }

        public int[] rangerPreordre()
        {
            List<int> list = new List<int>();
            rangerPreordreRec(racine, list);
            return list.ToArray();
        }

        private void rangerPreordreRec(Noeud root, List<int> list)
        {
            if (root != null)
            {
                list.Add(root.valeur);
                rangerPreordreRec(root.fg, list);
                rangerPreordreRec(root.fd, list);
            }
        }

        public int[] rangerPostordre()
        {
            List<int> list = new List<int>();
            rangerPostordreRec(racine, list);
            return list.ToArray();
        }

        private void rangerPostordreRec(Noeud root, List<int> list)
        {
            if (root != null)
            {
                rangerPostordreRec(root.fg, list);
                rangerPostordreRec(root.fd, list);
                list.Add(root.valeur);
            }
        }
    }
}
