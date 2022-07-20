using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFinal.DAL.Interfaces;
using TestFinal.Data;


namespace TestFinal.Models.Repositores
{
    public class GroupClassService: IGroupClassService

	{
		private readonly IGenericRepository<GroupClass> groupClassRepo;

		public GroupClassService(IGenericRepository<GroupClass> _groupClassRepo)
		{
			groupClassRepo = _groupClassRepo;
		}

		public async Task AddGroupClassAsync(GroupClass groupClass)
		{
			await groupClassRepo.Insert(groupClass);
		}
		public async Task DeleteGroupClassAsync(GroupClass groupClass)
		{
			await groupClassRepo.Delete(groupClass);
		}
		public async Task<GroupClass> GetGroupClassByIdAsync(int id)
		{
			return await groupClassRepo.GetById(id);
		}
		public List<GroupClass> GetGroupClassByName(string name)
		{
			return groupClassRepo.GetByCondition(o => o.Title.Equals(name));
		}
		public IEnumerable<GroupClass> ListAllGroupClass()
		{
			return groupClassRepo.GetAll();
		}
		public IEnumerable<GroupClass> ListAllGroupClassWith()
		{
			return groupClassRepo.GetAll(d => d.Title);
		}
		public async Task UpdateGroupClassAsync(GroupClass groupClass)
		{
			await groupClassRepo.Update(groupClass);
		}



	}
}
