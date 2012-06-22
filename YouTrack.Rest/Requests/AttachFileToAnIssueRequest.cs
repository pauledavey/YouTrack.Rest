﻿using System;
using System.IO;

namespace YouTrack.Rest.Requests
{
    class AttachFileToAnIssueRequest : YouTrackRequest, IYouTrackPostWithFileRequest
    {
        public AttachFileToAnIssueRequest(string issueId, string filePath) : base(String.Format("/rest/issue/{0}/attachment", issueId))
        {
            FilePath = filePath;
            Name = "files";

            ResourceBuilder.AddParameter("name", Path.GetFileNameWithoutExtension(filePath));
        }

        public string FilePath { get; private set; }
        public string Name { get; private set; }
    }
}