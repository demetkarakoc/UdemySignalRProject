﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		public EfMenuTableDal(SignalRContext context) : base(context)
		{
		}

		public void ChangeMenuTableStatusToFalse(int id)
		{
			using var  context = new SignalRContext();
			var values=context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
			values.Status = false;
			context.SaveChanges();
		}

		public void ChangeMenuTableStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var values = context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
			values.Status = true;
			context.SaveChanges();
		}

		public int MenuTableCount()
		{
			using var context = new SignalRContext();
			return context.MenuTables.Count();
		}
	}
}
