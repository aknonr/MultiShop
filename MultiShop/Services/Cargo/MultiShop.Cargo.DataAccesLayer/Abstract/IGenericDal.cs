using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccesLayer.Abstract
{

    //Repository Design Pattern Generic olarak yaptık
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        //T türünde id getirelecek
        T GetById(int id);

        //  Bütün veriyi liste halinde getirecek Metod
        List<T> GetAll();


    }
}
