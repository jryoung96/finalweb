using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Web_Final.Data;
using Web_Final.Models.Account;
using Web_Final.Models.WareHouse;

namespace Web_Final.Repositories
{
  
    
    public class FactoryRepository : IFactoryRepository
    {
        private readonly StockDbContext db;
        public FactoryRepository(StockDbContext stockDbContext)
        {
            db = stockDbContext;
        }
        public async Task<T1Account> Create(string p_name, string p_department, string p_position, string p_id, string p_pw) //계정생성
        {
            T1Account account = new()
            {
                Name = p_name,
                UserId = p_id,
                PassWord = p_pw,
                Position = p_position,
                Authority = 0,
                RegDate = DateTime.Now,
                DepartmentCode = p_department
            };
           await db.AddAsync(account);
           await db.SaveChangesAsync();
            return account;
        }

        public async Task<T1Account?> Delete(int id) // 계정삭제(경영지원부)
        {
            var e = await db.T1Accounts.FindAsync(id);
            if (e == null) return null;
            db.T1Accounts.Remove(e);
            await db.SaveChangesAsync();
            return e;
        }

        public async Task<T1Account?> FindId(string p_code) // 입력받아서 사원코드 찾기(경영지원팀)
        {
            var user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            return user;
        }

        public async Task<IEnumerable<T1InBound>> InBoundList() // 입고내역
        {
            var s = await db.T1InBounds.ToListAsync();
            return s;
        }

        public async Task<T1Account?> Login(string userid, string userpw) //로그인
        {
            var user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == userid && x.PassWord == userpw);
            if(user == null) return null;
            return user;
        }

        public async Task<IEnumerable<T1OutBound>> OutBoundList() // 출고내역
        {
            var s = await db.T1OutBounds.ToListAsync();
            return s;
        }

        public async Task<T1Account> ResetPw(string p_code) // 비밀번호 초기화(경영지원부)
        {
            T1Account user = await db.T1Accounts.FirstOrDefaultAsync(x => x.UserId == p_code.Trim());
            if (p_code == null) return null;
            user.PassWord = "0000";
            return user;
        }

        public async Task<IEnumerable<T1WareHouse>> Total_List() // 창고 총 현황
        {
            var s = await db.T1WareHouses.ToListAsync();
            return s;
        }

        public async Task<T1Account> Update(string p_code, string p_department) // 사원정보수정 (경영지원팀)
        {
            T1Account user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            if (user == null) return null;
            user.DepartmentCode = p_department;
            await db.SaveChangesAsync();
            return user;
        }

        public Task<T1Account> UpdatePw(int id) // 비밀번호 수정(사원이 직접)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T1Account>> List() //총사원 현황
        {
            var employees = await db.T1Accounts.ToListAsync();
            return employees;
        }
    }
}
