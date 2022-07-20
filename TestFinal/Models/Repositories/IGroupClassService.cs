using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Models.Repositores
{
    public interface IGroupClassService
    {
		public Task AddGroupClassAsync(GroupClass groupClass);
		public Task DeleteGroupClassAsync(GroupClass groupClass);
		public Task UpdateGroupClassAsync(GroupClass groupClass);
		public IEnumerable<GroupClass> ListAllGroupClass();
		public IEnumerable<GroupClass> ListAllGroupClassWith();
		public Task<GroupClass> GetGroupClassByIdAsync(int id);
		public List<GroupClass> GetGroupClassByName(string name);
	}
}
