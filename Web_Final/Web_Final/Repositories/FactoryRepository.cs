using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Web_Final.Data;
using Web_Final.Models.Account;
using Web_Final.Models.Process;
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
       //계정생성
        public async Task<T1Account> Create(string p_name, string p_department, string p_position, string p_id, string p_pw) 
        {
            T1Account account = new()
            {
                Name = p_name,
                UserId = p_id,
                PassWord = p_pw,
                Position = p_position,
                Authority = 1,
                RegDate = DateTime.Now,
                DepartmentCode = p_department
            };
           await db.AddAsync(account);
           await db.SaveChangesAsync();
            return account;
        }
		// 계정삭제(경영지원부)
		public async Task<T1Account?> Delete(string p_code) 
        {
            var user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            if (user == null) return null;
            db.T1Accounts.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }
		// 입력받아서 사원ID 찾기(경영지원팀)
		public async Task<T1Account?> FindId(string p_code) 
        {
            var user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            return user;
        }
		// 입고내역
		public async Task<IEnumerable<T1InBound>> InBoundList() 
        {
            var s = await db.T1InBounds.ToListAsync();
            return s;
        }
		//로그인
		public async Task<T1Account?> Login(string userid, string userpw) 
        {
            var user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == userid.Trim() && x.PassWord == userpw);
            if(user == null) return null;
            return user;
        }
		// 출고내역
		public async Task<IEnumerable<T1OutBound>> OutBoundList() 
        {
            var s = await db.T1OutBounds.ToListAsync();
            return s;
        }
		// 비밀번호 초기화(경영지원부)
		public async Task<T1Account> ResetPw(string p_code) 
        {
            T1Account user = await db.T1Accounts.FirstOrDefaultAsync(x => x.UserId == p_code.Trim());
            if (p_code == null) return null;
            user.PassWord = "0000";
            await db.SaveChangesAsync();
            return user;
        }
		// 창고 총 현황
		public async Task<IEnumerable<T1WareHouse>> Total_List() 
        {
            var s = await db.T1WareHouses.ToListAsync();
            return s;
        }
		// 사원정보수정 (경영지원팀)
		public async Task<T1Account> Update(string p_code, string p_department) 
        {
            T1Account user = await db.T1Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            if (user == null) return null;
            user.DepartmentCode = p_department;
            await db.SaveChangesAsync();
            return user;
        }
		// 비밀번호 수정(사원이 직접)
		public async Task<T1Account> UpdatePw(int? uid,string pw) 
        {

            T1Account user = await db.T1Accounts.FirstOrDefaultAsync(x => x.Id == uid);
            if (user == null) return null;
            user.PassWord = pw;
            await db.SaveChangesAsync();
            return user;
        }

		//총사원 현황
		public async Task<IEnumerable<T1Account>> List() 
        {
            var employees = await db.T1Accounts.ToListAsync();
            return employees;
        }

       //생산현황
       public async Task<IEnumerable<T1Item>> ChartList()
        {
            var list = await db.T1Items.ToListAsync();
            return list;
        }

        Task<T1Item?> IFactoryRepository.ChartList()
        {
            throw new NotImplementedException();
        }


    }
}
