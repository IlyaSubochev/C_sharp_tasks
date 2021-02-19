using System;
using System.Collections.Generic;
namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }
    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;
        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }
        public void AddVertex(int value) // добавление новой вершины  с значением value в свободную позицию массива vertex
        {
            for (int i = 0; i < max_vertex; i++)
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex(value);
                    return;
                }
        }
        // здесь и далее, параметры v -- индекс вершины в списке vertex
        public void RemoveVertex(int v) // код удаления вершины со всеми её рёбрами
        {
            if (InRange(v) && vertex[v] != null)
            {
                for (int i = 0; i < max_vertex; i++)
                {
                    m_adjacency[v, i] = 0;
                    m_adjacency[i, v] = 0;
                }
                vertex[v] = null;
            }
        }
        public bool IsEdge(int v1, int v2) // true если есть ребро между вершинами v1 и v2
        {
            if (InRange(v1, v2)) 
                return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
            return false;
        }
        public void AddEdge(int v1, int v2) // добавление ребра между вершинами v1 и v2
        {
            if (InRange(v1, v2) && vertex[v1] != null && vertex[v2] != null)
            {
                m_adjacency[v1, v2] = 1;
                m_adjacency[v2, v1] = 1;
            }
        }
        public void RemoveEdge(int v1, int v2) // удаление ребра между вершинами v1 и v2
        {
            if (InRange(v1, v2) && vertex[v1] != null && vertex[v2] != null)
            {
                m_adjacency[v1, v2] = 0;
                m_adjacency[v2, v1] = 0;
            }
        }

        private bool InRange(int v)
        {
            return v < max_vertex;
        }

        private bool InRange(int a, int b)
        {
            return a < max_vertex && b < max_vertex;
        }
    }
}
