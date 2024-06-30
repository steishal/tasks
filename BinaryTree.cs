namespace BinaryTree
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int value)
        {
            data = value;
            left = null;
            right = null;
        }
    }

    public class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }
        public void PrintTree()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private Node InsertRec(Node root, int value)
        {
            if (root == null)
            {
                return new Node(value);
            }

            if (value < root.data)
            {
                root.left = InsertRec(root.left, value);
            }
            else if (value > root.data)
            {
                root.right = InsertRec(root.right, value);
            }

            return root;
        }

        public void Delete(int value)
        {
            root = DeleteRec(root, value);
        }

        private Node DeleteRec(Node root, int value)
        {
            if (root == null)
            {
                return root;
            }

            if (value < root.data)
            {
                root.left = DeleteRec(root.left, value);
            }
            else if (value > root.data)
            {
                root.right = DeleteRec(root.right, value);
            }
            else
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }
                root.data = FindMinRec(root.right);
                root.right = DeleteRec(root.right, root.data);
            }

            return root;
        }
        public Node Find(int value)
        {
            return FindRec(root, value);
        }

        private Node FindRec(Node root, int value)
        {
            if (root == null || root.data == value)
            {
                return root;
            }

            if (value < root.data)
            {
                return FindRec(root.left, value);
            }
            else
            {
                return FindRec(root.right, value);
            }

        }

        public Node GetLeftPredecessor(Node target)
        {
            Node predecessor = null;
            Node current = root;

            while (current != null)
            {
                if (current.data < target.data)
                {
                    predecessor = current;
                    current = current.right;
                }
                else
                {
                    current = current.left;
                }
            }

            return predecessor;
        }

        public int FindMin()
        {
            return FindMinRec(root);
        }

        private int FindMinRec(Node root)
        {
            if (root.left == null)
            {
                return root.data;
            }

            return FindMinRec(root.left);

        }
        public void InOrderTraversal(Node root)
        {
            if (root == null)
                return;
            InOrderTraversal(root.left);
            Console.Write(root.data + " ");
            InOrderTraversal(root.right);
        }
        public void BreadthTraversal()
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.Write(current.data + " ");

                if (current.left != null)
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);
            }
        }
        public void DepthTraversal()
        {
            if (root != null)
            {
                Stack<Node> stack = new Stack<Node>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    Node node = stack.Pop();
                    Console.Write(node.data + " ");

                    if (node.right != null)
                        stack.Push(node.right);
                    if (node.left != null)
                        stack.Push(node.left);
                }
            }
        }
    }
    public class Empty
    {
        static void Main()
        {
            Tree tree = new Tree();

            tree.Insert(10);
            tree.Insert(8);
            tree.Insert(70);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(40);

            Console.WriteLine("Обход по ширине:");
            tree.BreadthTraversal();
            Console.WriteLine();
            Console.WriteLine("Обход в глубину:");
            tree.DepthTraversal();
            Console.WriteLine();

            Node foundNode = tree.Find(70);
            if (foundNode != null)
            {
                Console.WriteLine($"{70} есть");
            }
            else
            {
                Console.WriteLine($"{70} нет");
            }

            tree.Delete(8);
            Console.WriteLine($"Удаленный узел: {8}");

            Console.WriteLine("Обход по ширине после удаления:");
            tree.BreadthTraversal();
            Console.WriteLine();
            Console.WriteLine("Обход в глубину после удаления:");
            tree.DepthTraversal();
        }
    }
}

