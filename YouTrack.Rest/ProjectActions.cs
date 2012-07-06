using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class ProjectActions : IProjectActions
    {
        public ProjectActions(string projectId, IConnection connection)
        {
            Id = projectId;
            Connection = connection;
        }

        protected IConnection Connection { get; private set; }
        public string Id { get; private set; }

        public IEnumerable<IIssue> GetIssues()
        {
            GetIssuesInAProjectRequest request = new GetIssuesInAProjectRequest(Id);

            return GetIssues(request);
        }

        public IEnumerable<IIssue> GetIssues(string filter)
        {
            GetIssuesInAProjectRequest request = new GetIssuesInAProjectRequest(Id, filter);

            return GetIssues(request);
        }

        private IEnumerable<IIssue> GetIssues(GetIssuesInAProjectRequest request)
        {
            List<Deserialization.Issue> issues = Connection.Get<List<Deserialization.Issue>>(request);

            return issues.Select(i => i.GetIssue(Connection));
        }
    }
}