using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

		public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

		public void TChangesStatusToFalse(int id)
		{
			_discountDal.ChangesStatusToFalse(id);
		}

		public void TChangesStatusToTrue(int id)
		{
			_discountDal.ChangesStatusToTrue(id);
		}

		public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);
        }

        public List<Discount> TGetListAll()
        {
           return _discountDal.GetListAll();
        }

		public List<Discount> TGetListByStatusTrue()
		{
			return _discountDal.GetListByStatusTrue();
		}

		public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
