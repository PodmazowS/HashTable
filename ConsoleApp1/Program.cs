using System;
namespace ConsoleApp1
{
    class Node
    {
        public Node prev;
        public Node next;
        public char ch;

        public Node(char ch)
        {
            this.ch = ch;
        }
    }
    class Program
    {

        static void Main()
        {
            Node head;
            Node current;
            int t = int.Parse(Console.ReadLine());
            string output = "";
            for (int j = 0; j < t; ++j)
            {
                string str = Console.ReadLine();
                head = null;
                current = null;
                foreach (char c in str)
                {
                    if (c != '<' && c != '>' && c != '-')
                    {
                        if (current == null)
                        {
                            current = new Node(c);
                            current.next = head;
                            if (head != null) head.prev = current;
                            head = current;
                        }
                        else
                        {
                            Node newNode = new Node(c);
                            newNode.next = current.next;
                            newNode.prev = current;
                            if (current.next != null) current.next.prev = newNode;
                            current.next = newNode;
                            current = newNode;
                        }
                    }
                    else if (c == '<')
                    {
                        if (current == null) continue;
                        current = current.prev;
                    }
                    else if (c == '>')
                    {
                        if (current == null) current = head;
                        else
                        if (current.next != null) current = current.next;
                    }
                    else
                    {
                        if (current == null) continue;
                        if (current.prev == null)
                        {
                            head = current.next;
                            current = null;
                            if (head != null) head.prev = null;
                        }
                        else
                        {
                            current.prev.next = current.next;
                            if (current.next != null) current.next.prev = current.prev;
                            current = current.prev;
                        }
                    }
                }
                while (head != null)
                {
                    output += head.ch;
                    head = head.next;
                }
                output += "\n";
            }
            Console.Write(output);
        }
    }
}