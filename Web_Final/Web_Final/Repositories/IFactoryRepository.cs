using Web_Final.Models.Account;
using Web_Final.Models.WareHouse;

namespace Web_Final.Repositories
{
    public interface IFactoryRepository
    {
       
        Task<T1Account> Create(string p_name, string p_department, string p_position, string p_id, string p_pw); //계정생성
        Task<T1Account?> Delete(int id);
        Task<T1Account> Update(string p_code, string p_department); // 사원 정보수정 (경영지원팀)
        Task<T1Account> UpdatePw(int id); // 비밀번호 수정(사원이 직접)
        Task<T1Account> ResetPw(string p_code); // 비밀번호 0000으로 리셋 (경영지원부)
        Task<T1Account?> Login(string id, string pw); //로그인
        Task<IEnumerable<T1InBound>> InBoundList(); //입고내역 (구매팀한테 몇개 받았나), 생산팀만 확인가능
        Task<IEnumerable<T1OutBound>> OutBoundList();  //불출내역 (창고에서 부품 몇개나 썼나), 생산팀만 확인가능
        Task<IEnumerable<T1WareHouse>> Total_List(); //재고 현황 (창고), 생산팀만 확인가능
        Task<T1Account?> FindId(string p_code); //사원번호 입력해서 찾기
        
        

    }
}
