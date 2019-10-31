using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UITableViewCoded.Models;

namespace UITableViewCoded.Services
{
    public interface ISpeakerService
    {
        Task<List<Speaker>> GetSpeakersAsync();
    }
}
