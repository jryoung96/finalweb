using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Final.Models.Data;
using Web_Final.Repositories;

namespace Web_Final.Controllers
{
    public class FactoryController : Controller
    {
        //repo
        private readonly IFactoryRepository factoryRepository;
        //DbContext
        private readonly StockDbContext db;
        //컨트롤러 생성자
        public FactoryController(IFactoryRepository _factoryRepository, StockDbContext _db)
        {
            db = _db;
            factoryRepository = _factoryRepository;
        }
        //로그인
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> GoLogin(string userid, string userpw) // 변수명은 form태그안에 input태그 name값과 동일해야 함!!!
        {
            var user = await factoryRepository.Login(userid, userpw);
            if(user != null) 
            {
                HttpContext.Session.SetInt32("userid", (int)user.Id); // 로그인한 유저 uid 세션에 저장 (이거로 수정 삭제)
                HttpContext.Session.SetString("department", user.DepartmentCode);// 부서코드 (메뉴출력 다르게 할때 써먹음)
                HttpContext.Session.SetInt32("authority", user.Authority); //경영지원부 아이디로 로그인 할 경우, 아이디생성 권한(0일경우 가능)
                HttpContext.Session.SetString("username", user.Name); // 로그인한 사원정보 볼 수 있게
            }
            return View("Index",user);
        }
        //로그아웃
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("department");
            HttpContext.Session.Remove("authority");
            HttpContext.Session.Remove("username");
            return View("Logout");
        }
        //비밀번호 변경(사원이 직접변경)
        public IActionResult UpdatePw()
        {
            return View();
        }
        //계정 생성(경영)
        public IActionResult Create(string p_name, string p_department, string p_position, string p_id, string p_pw)
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateId(string p_name, string p_department, string p_position, string p_id, string p_pw)
        {
            var new_user = await factoryRepository.Create(p_name, p_department, p_position, p_id, p_pw);
            return View("Index");
        }
        //사원 조회(경영)
        public IActionResult List()
        {
            return View();
        }
        //사원정보 수정(경영)
        public IActionResult UpdateEmp()
        {
            return View();
        }
        [HttpPost]
        [ActionName("UpdateEmp")]
        public IActionResult Update(string p_name, string p_department)
        {
            return null;
        }
        //창고자재 목록 (구매팀)
        public IActionResult StockList()
        {
            return View();
        }
        //입고내역 (구매팀)
        public IActionResult InBoundList()
        {
            return View();
        }
        //불출내역 (구매팀 >> 생산팀)
        public IActionResult OutBoundList()
        {
            return View();
        }
        //입고내역(생산부)
        public IActionResult InBound_P()
        {
            return View();
        }
        //출고내역 (생산)
        public IActionResult OutBound_P()
        {
            return View();
        }
        //차트 (생산)
        public IActionResult Total_Chart()
        {
            return View();
        }

    }
}
