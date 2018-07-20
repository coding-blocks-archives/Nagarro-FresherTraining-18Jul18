using System;
using System.Collections.Generic;

namespace Tree
{
    public class BinaryTree{
        TreeNodeSpecial<int> root;

        public BinaryTree(){
            root = CreateTree();
        }

        private TreeNode<int> CreateTree(){
            int x = int.Parse(Console.ReadLine());
            if (x == -1){
                // this means we should not create a tree
                return null;
            }

            TreeNode<int> newTreeNode = new TreeNodeSpecial<int>(x);
            // Console.Write("Enter the left child of " + x + " " );
            newTreeNode.SetLeft(CreateTree());
            // Console.Write("Enter the right child of " + x + " ");
            newTreeNode.SetRight(CreateTree());
            return newTreeNode;
        }

        public void PrintInOrder(){
            this.PrintInOrder(root);
        }

        private void PrintInOrder(TreeNode<int> root){
            if (root == null) return;
            PrintInOrder(root.GetLeft());
            Console.Write(root.GetData() + " ");
            PrintInOrder(root.GetRight());
        }

        public void PrintInOrderSpecial(){
            this.PrintInOrderSpecial(root);
        }
        
        private void PrintInOrderSpecial(TreeNodeSpecial<int> root){
            if (root == null) return;
            PrintInOrder(root.GetLeft());
            Console.Write(root.GetData() + "(" + 
                         (root.GetNext() != null ? root.GetNext().GetData() : 0) + ") ");
            PrintInOrder(root.GetRight());
        }


        public void PrintLevelWise(){
            // prints the levelwise traversal of a tree
            if (root == null) {
                Console.WriteLine("Tree is empty dude!!!");
                return;
            }
            // TODO virtual abstract difference
            // TODO what is the difference between const reference and const memory (aka read only)
            
            Queue<TreeNode<int>> nodesToProcess = new Queue<TreeNode<int>>();
            const TreeNode<int> MARKER = null;
            
            nodesToProcess.Enqueue(root);
            nodesToProcess.Enqueue(MARKER);

            while(nodesToProcess.Count != 0){
                TreeNode<int> curNode = nodesToProcess.Dequeue();
                
                if (curNode == MARKER){
                    // this is null and the curLevel HAS BEEN printed
                    // this also means that children of curLevel are pushed into Queue
                    Console.WriteLine();
                    if (nodesToProcess.Count != 0) nodesToProcess.Enqueue(MARKER);
                    continue;
                }

                Console.Write(curNode.GetData() + " ");
                
                if (curNode.GetLeft() != null) nodesToProcess.Enqueue(curNode.GetLeft());
                if (curNode.GetRight() != null) nodesToProcess.Enqueue(curNode.GetRight());
            }
        }

        // public void ConnectLevels(){
        //     Queue<TreeNodeSpecial<int>> nodesToProcess = new Queue<TreeNode<int>>();
        //     const TreeNodeSpecial<int> MARKER = null;
            
        //     nodesToProcess.Enqueue(root);
        //     nodesToProcess.Enqueue(MARKER);

        //     while(nodesToProcess.Count != 0){
        //         TreeNodeSpecial<int> curNode = nodesToProcess.Dequeue();
        //         if (curNode == MARKER){
        //             if (nodesToProcess.Count != 0) nodesToProcess.Enqueue(MARKER);
        //             continue;
        //         }
        //         curNode.next = nodesToProcess.Peek();
        //         if (curNode.GetLeft() != null) nodesToProcess.Enqueue(curNode.GetLeft());
        //         if (curNode.GetRight() != null) nodesToProcess.Enqueue(curNode.GetRight());
        //     }

        // }

        // TODO Implement this class which initialises the member of special node
        // public class BinaryTreeSpecial : BinaryTree {
        //     TreeNodeSpecial<int> root;

        //     public BinaryTreeSpecial() : BinaryTreeSpecial(){
        //     }
        // }
    }
}