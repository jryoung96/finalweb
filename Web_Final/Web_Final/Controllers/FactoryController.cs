using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using Web_Final.Data;
using Web_Final.Models.Account;
using Web_Final.Repositories;

namespace Web_Final.Controllers
{
    public class FactoryController : Controller
    {
        //repo
        private readonly IFactoryRepository factoryRepository;
        //컨트롤러 생성자
        public FactoryController(IFactoryRepository _factoryRepository)
        {
            factoryRepository = _factoryRepository;
        }
        //홈화면
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult userinfo()
        {
            return View();
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
                return View("userinfo", user);
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
        //비밀번호 변경 메소드
        [HttpPost]
        [ActionName("UpdatePw")]
        public async Task<IActionResult> Update(string pw)
        {
            int? uid = HttpContext.Session.GetInt32("userid");
            var result = await factoryRepository.UpdatePw(uid,pw);
            return View("index");
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


        //사원정보 수정페이지
        public  IActionResult UpdateEmp()
        {
            return View();
        }
        [HttpPost]
        [ActionName("UpdateEmp")]
        public async Task<IActionResult> Update_test(string p_code,string p_department)
        {
			var user = await factoryRepository.Update(p_code, p_department);
            return View("index");
		}
    

        //존재하는 사원코드인지 검사
        public async Task<IActionResult> Check(string p_code) //실제 유저가 사용하는 id값을 입력받아야 돼
        {
            var user = await factoryRepository.FindId(p_code);
            if (user == null) return Json("unavailable");
            else 
                return Json("available");
        }
        
       
        public IActionResult Reset()
        {
            return View();
        }
        //비밀번호 0000초기화
        [HttpPost]
        [ActionName("Reset")]
        public async Task<IActionResult> ResetPw(string p_code) //비밀번호 초기화, p_code : 사원ID
        {
          var user = await factoryRepository.ResetPw(p_code);
            return View();
        }

        //사원ID 삭제 페이지
        public IActionResult DeleteEmp()
        {
            return View();
        }
        //사원ID 삭제 (경영지원팀)
        [HttpPost]
        [ActionName("DeleteEmp")]
        public async Task<IActionResult> Delete(string p_code)
        {
            var user = await factoryRepository.Delete(p_code);
            return View();
        }

        //==========================================================================
        //테이블 조회 및 차트

        //사원 조회(경영)
        public async Task<IActionResult> EmployeesList()
		    {
			    var list = await factoryRepository.List(); //사원목록
			    return View(list);
		    }
		//창고자재 목록 (구매팀,생산팀)
		public async Task<IActionResult> StockList()
        {
            var list = await factoryRepository.Total_List();
            return View(list);
        }
        //입고내역 (구매팀)
        public async Task<IActionResult> InBoundList()
        {
            var list = await factoryRepository.InBoundList();
            return View(list);
        }
        //출고내역 (구매팀)
        public async Task<IActionResult> OutBoundList()
        {
			var list = await factoryRepository.OutBoundList();

			return View(list);
        }
        //차트 (생산)
        public async Task<IActionResult> Total_Chart()
        {
            var list = await factoryRepository.ChartList();
            return View(list);
        }

    }
}
