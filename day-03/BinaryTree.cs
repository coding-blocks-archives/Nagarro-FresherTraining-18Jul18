using System;

namespace Tree
{
    public class BinaryTree{
        TreeNode<int> root;

        public BinaryTree(){
            root = CreateTree();
        }

        private TreeNode<int> CreateTree(){
            int x = int.Parse(Console.ReadLine());
            if (x == -1){
                // this means we should not create a tree
                return null;
            }

            TreeNode<int> newTreeNode = new TreeNode<int>(x);
            Console.Write("Enter the left child of " + x + " " );
            newTreeNode.SetLeft(CreateTree());
            Console.Write("Enter the right child of " + x + " ");
            newTreeNode.SetRight(CreateTree());
            return newTreeNode;
        }

        public void PrintInOrder(){
            this.PrintInOrder(root);
        }

        private void PrintInOrder(TreeNode<int> root){
            if (root == null) return;
            PrintInOrder(root.GetLeft());
            Console.Write(root.GetData());
            PrintInOrder(root.GetRight());
        }

        public void PrintLevelWise(){
            // prints the levelwise traversal of a tree
        }
    }
}