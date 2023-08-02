using Web_Final.Data;
using Web_Final.Models.Account;
using Web_Final.Models.Process;
using Web_Final.Models.WareHouse;
using Web_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Principal;

namespace Web_Final.Repositories
{
  
    
    public class FactoryRepository : IFactoryRepository
    {
        private readonly AccountDbContext account_db;
        private readonly MProcessDbcontext process_db;
        public FactoryRepository(AccountDbContext db1, MProcessDbcontext db2 )
        {
            account_db = db1; 
            process_db = db2;
        }
       //계정생성
        public async Task<Account> Create(string p_name, string p_department, string p_position, string p_id, string p_pw) 
        {
            Account account = new()
            {
                Name = p_name,
                UserId = p_id,
                PassWord = p_pw,
                Position = p_position,
                Authority = 1,
                RegDate = DateTime.Now,
                DepartmentCode = p_department
            };
           await account_db.AddAsync(account);
           await account_db.SaveChangesAsync();
            return account;
        }
		// 계정삭제(경영지원부)
		public async Task<Account?> Delete(string p_code) 
        {
            var user = await account_db.Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            if (user == null) return null;
            account_db.Accounts.Remove(user);
            await account_db.SaveChangesAsync();
            return user;
        }
		// 입력받아서 사원ID 찾기(경영지원팀)
		public async Task<Account?> FindId(string p_code) 
        {
            var user = await account_db.Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            return user;
        }
		// 입고내역
		public async Task<IEnumerable<InBound>> InBoundList() 
        {
            var s = await process_db.InBounds.ToListAsync();
            return s;
        }
		//로그인
		public async Task<Account?> Login(string userid, string userpw) 
        {
            var user = await account_db.Accounts.FirstOrDefaultAsync(x=>x.UserId == userid.Trim() && x.PassWord == userpw);
            if(user == null) return null;
            return user;
        }
		// 출고내역
		public async Task<IEnumerable<OutBound>> OutBoundList() 
        {
            var s = await process_db.OutBounds.ToListAsync();
            return s;
        }
		// 비밀번호 초기화(경영지원부)
		public async Task<Account> ResetPw(string p_code) 
        {
            Account user = await account_db.Accounts.FirstOrDefaultAsync(x => x.UserId == p_code.Trim());
            if (p_code == null) return null;
            user.PassWord = "0000";
            await account_db.SaveChangesAsync();
            return user;
        }
		// 창고 총 현황
		public async Task<IEnumerable<WareHouse>> Total_List() 
        {
            var s = await process_db.WareHouses.ToListAsync();
            return s;
        }
		// 사원정보수정 (경영지원팀)
		public async Task<Account> Update(string p_code, string p_department) 
        {
            Account user = await account_db.Accounts.FirstOrDefaultAsync(x=>x.UserId == p_code.Trim());
            if (user == null) return null;
            user.DepartmentCode = p_department;
            await account_db.SaveChangesAsync();
            return user;
        }
		// 비밀번호 수정(사원이 직접)
		public async Task<Account> UpdatePw(int? uid,string pw) 
        {

            Account user = await account_db.Accounts.FirstOrDefaultAsync(x => x.Id == uid);
            if (user == null) return null;
            user.PassWord = pw;
            await account_db.SaveChangesAsync();
            return user;
        }

		//총사원 현황
		public async Task<IEnumerable<Account>> List() 
        {
            var employees = await account_db.Accounts.ToListAsync();
            return employees;
        }


        //생산현황 (차트에서 끄집어 쓸거)
        public async Task<IEnumerable<ItemCount>> GetCountAsync()
        {
            var result = await process_db.Items
                .Join(process_db.CreateLots,
                item => item.Code,
                c_lot => c_lot.ItemCode,
                (item, lot_his) => new { item, lot_his })
                .Where(x=>x.item.Type == "FERT")
                .GroupBy(x => new { x.item.Name, x.item.Code, x.lot_his.RegDate })
                .Select(h => new ItemCount
                {
                    Name = h.Key.Name,
                    Code = h.Key.Code,
                    RegDate = h.Key.RegDate,
                    Count = h.Sum(x=>x.lot_his.Amount1)
                }).OrderBy(x=>x.Id)
                .ToListAsync();
            return result;
        }

		/*
					 var result = await process_db.Items
				 .Join(process_db.CreateLots,
					 item => item.Code,
					 c_lot => c_lot.ItemCode,
					 (item, c_lot) => new { item, c_lot })
				 .Join(process_db.LotHis,
					 combined => combined.c_lot.ItemCode,
					 lot_his => lot_his.ItemCode,
					 (combined, lot_his) => new { combined.item, combined.c_lot, lot_his })
				 .Where(x => x.item.Type == "FERT" && x.lot_his.ActionCode == "End")
				 .GroupBy(x => new { x.item.Name, x.item.Code, x.lot_his.RegDate })
				 .Select(h => new ItemCount
				 {
					 Name = h.Key.Name,
					 Code = h.Key.Code,
					 RegDate = h.Key.RegDate,
					 Count = h.Sum(x => x.c_lot.Amount1)
				 }).OrderBy(x=>x.Id)
				 .ToListAsync();

			 return result;
		 */




	}
}
