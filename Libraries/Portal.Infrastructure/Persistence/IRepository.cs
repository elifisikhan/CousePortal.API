using Portal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistence
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int Id);

        IQueryable<T> GetAll { get; }   // db tüm kayıtları önce where sorgusunu çalıştırarak getirecek.

        IQueryable<T> GetAllNoTracking { get; } // EF de tracking açık olunca sorgu daha yavaş oluyor. Silme ve Update işlemlerini tracking ile yapabiliyoruz. 
                                                // Sadece veri çekmek istediğimizde (üzerinde değişiklik yapmayacaksak tracking özelliğini kapatmalıyız)

        T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        // _articleRepository.Get(f => f.IsActive && f.Id > 20 , y=> y.Category, z => z.Comment); 

        IQueryable<T> GetMany(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        // GEtAll mtd gibi fakat Get metotunda where kullanmadan sorgu yapabileceğiz
        
        T InsertWithoutCommit(T entity); // her seferinde gelen modeli (foreach ile dönerken) db'e kaydedersem perf. kaybı yaşarım. 
                                         // listeye alıp foreach dışında tek bir commit ile db'e eklemek için bu mtd kullanılacak

        int InsertBulk(IEnumerable<T> entities); // datayı bulk olarak kaydetmemi sağlayacak

        /*
           Bulk Insert Nedir?
           Projemizde milyonlarca dataların aynı anda insert işlemlerinin yavaş olmasının sebebi,
           her bir kayıtı teker teker kayıt etmesidir. Yavaş olması sebebiyle bunun için bir yöntem geliştirilmiştir. 
           Insert edilirken kayıtların tek tek değilde bir tabloymuş gibi olduğu gibi tüm dataları başka bir tabloya insert edilmek için
           Bulk Insert yöntemi kullanılılır.
         */

        int Update(T entity);

        int UpdateWithoutCommit(T entity);

        int Delete(T entity);

        int Remove(T entity);

        int Commit();

        int DeleteBulk(IEnumerable<T> entities);

        bool Any(Expression<Func<T, bool>> expression);
    }
}
