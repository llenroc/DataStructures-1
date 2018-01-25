﻿using LeetcodeSolutions.DataStructures;
using System.Collections.Generic;

namespace LeetcodeSolutions.BinaryTree
{
    // Leetcode 226
    public class InvertBinaryTree
    {
        public BinaryTreeNode InvertTreeRecursive(BinaryTreeNode root)
        {
            if (root == null || (root.Left == null && root.Right == null))
                return root;

            var left = InvertTreeRecursive(root.Left);
            root.Left = InvertTreeRecursive(root.Right);
            root.Right = left;

            return root;
        }

        // Tx = O(n)
        // Sx = O(1)
        public BinaryTreeNode InvertTreeInPlace(BinaryTreeNode root)
        {
            if (root == null)
                return root;

            Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();
            nodes.Enqueue(root);

            while(nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var left = node.Left;
                node.Left = node.Right;
                node.Right = left;

                if (node.Left != null)
                    nodes.Enqueue(node.Left);

                if (node.Right != null)
                    nodes.Enqueue(node.Right);
            }

            return root;
        }

        // Tx = O(n)
        // Sx = O(n)
        public BinaryTreeNode InvertTree(BinaryTreeNode root)
        {
            if (root == null)
                return root;

            Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();
            nodes.Enqueue(root);

            Queue<BinaryTreeNode> reverseNodes = new Queue<BinaryTreeNode>();

            BinaryTreeNode ReversedTreeRoot = new BinaryTreeNode(root.Val);
            BinaryTreeNode current = ReversedTreeRoot;
            reverseNodes.Enqueue(current);

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                current = reverseNodes.Dequeue();

                if (node.Left != null)
                {
                    nodes.Enqueue(node.Left);
                    current.Right = new BinaryTreeNode(node.Left.Val);
                    reverseNodes.Enqueue(current.Right);
                }

                if (node.Right != null)
                {
                    nodes.Enqueue(node.Right);
                    current.Left = new BinaryTreeNode(node.Right.Val);
                    reverseNodes.Enqueue(current.Left);
                }
            }

            return ReversedTreeRoot;
        }
    }
}
