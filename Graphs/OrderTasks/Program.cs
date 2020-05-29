using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTasks
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static Stack<Project> OrderGraph(List<Project> projects)
        {
            Stack<Project> stack = new Stack<Project>();
            foreach (var project in projects)
            {
                if (!DoDfs(project, stack))
                {
                    return null;
                }
            }

            return stack;
        }

        static bool DoDfs(Project project, Stack<Project> stack)
        {
            if (project.ProjectState == Project.State.PARTIAL)
            {
                return false;
            }

            if (project.ProjectState == Project.State.BLANK)
            {
                foreach (var child in project.children)
                {
                   if (!DoDfs(child, stack))
                    {
                        return false;
                    }
                }

                project.ProjectState = Project.State.COMPLETED;
                stack.Push(project);
            }

            return true;
        }
    }

    class Graph
    {
        public List<Project> nodes = new List<Project>();
        public Dictionary<string, Project> projectMap = new Dictionary<string, Project>();

        public Project CreateOrGetProject(string name)
        {
            Project project = null;
            if (!projectMap.ContainsKey(name))
            {
                project = new Project();
                project.Name = name;
                projectMap.Add(name, project);
            }

            return projectMap[name];
        }

        public void AddNode(string from, string to)
        {
            Project projectFrom = CreateOrGetProject(from);
            Project projectTo = CreateOrGetProject(to);
            projectFrom.AddDependency(projectTo);
        }
    }

    class Project
    {
        public enum State
        {
            BLANK = 0,
            PARTIAL,
            COMPLETED
        }

        public State ProjectState
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<Project> children = new List<Project>();

        public int IncomingDependencies
        {
            get;
            set;
        }

        public void AddDependency(Project project)
        {
            this.children.Add(project);
            project.IncomingDependencies++;
        }
    }
}
