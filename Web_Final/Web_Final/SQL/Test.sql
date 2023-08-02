delete from T1_Department;

insert into [T1_Department] (DepartmentCode)
values
('001')
,('002')
,('003');
--Acount--
-- 1 : 경영지원, 2: 구매, 3: 생산 
delete from T1_Acount;

insert into [LTDB].[dbo].[T1_Account] (UserId,Name,Position,Authority,PassWord,RegDate,DepartmentCode)
values
('admin1','김건우','팀장',0,'1234',GETDATE(),'001')
,('admin2','박재걸','팀장',0,'1234',GETDATE(),'002')
,('admin3','이용학','팀장',0,'1234',GETDATE(),'003')

SELECT * FROM T1_Account;
--WareHouse--
delete from T1_WareHouse;

insert into [LTDB].[dbo].[T1_WareHouse] (Product,Item,Amount)
values
('RTX1060','GraphicCard',100)
,('RTX2080','GraphicCard',100)
,('RTX3080','GraphicCard',100)
,('RTX4070','GraphicCard',100)

insert into [LTDB].[dbo].[T1_WareHouse] (Product,Item,Amount)
values
('Corei3','CPU',100)
,('Corei5','CPU',100)
,('Corei7','CPU',100)
,('Corei9','CPU',100)


delete from T1_InBound;

INSERT INTO [LTDB].[dbo].[T1_InBound] ( Product,Amount ,Vendor, RegDate, Contact)
VALUES 
((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei9'),20,'다나와', GETDATE(), '김건우')
,((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei7'),20,'다나와', GETDATE(), '김건우')
,((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei5'),20,'다나와', GETDATE(), '김건우')
,((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei3'),20,'다나와', GETDATE(), '김건우')
--Process 추가후 다시---


delete from T1_OutBound;
INSERT INTO [LTDB].[dbo].[T1_OutBound] (Product,Amount,Contact,RegDate)
VALUES
('Corei9',20,'김건우',GETDATE())
,('Corei7',20,'김건우',GETDATE())
,('Corei5',20,'김건우',GETDATE())
,('Corei3',20,'김건우',GETDATE())
------------------------------------------------------------------------------------------------------------
--Factory--
delete from T1_Factory;
insert into [LTDB].[dbo].[T1_Factory] (Code,Name,Constructor,RegDate)
values
('F_COM_001','컴퓨터공장','김건우',GETDATE())
,('F_COM_0012','컴퓨터공장2','김건우',GETDATE())

--Equiment--

delete from T1_Equipment;
insert into [LTDB].[dbo].[T1_Equipment] (Code,Name,Comment,Status,Event,Constructor,RegDate)
values
('Equip01','설비1','','Ready','NON','김건우',GETDATE())
,('Equip02','설비2','','Ready','NON','김건우',GETDATE())
,('Equip03','설비3','','Ready','NON','김건우',GETDATE())
,('Equip04','설비4','','Ready','NON','김건우',GETDATE())

--Item--

delete from T1_Item;
insert into [LTDB].[dbo].[T1_Item] (Code,Name,Type,Constructor,RegDate)
Values
('C_001','컴퓨터corei3','FERT','김건우',GETDATE())
,('C_002','컴퓨터corei5','FERT','김건우',GETDATE())
,('C_003','컴퓨터corei7','FERT','김건우',GETDATE())
,('C_004','컴퓨터corei9','FERT','김건우',GETDATE())

--Process--
delete from t1_MProcess;
insert into [LTDB].[dbo].[T1_MProcess] (Code,Name,Coment,EquipCode,StockUnit1,StockUnit2,Constructor,RegDate)
Values
('P_Test01','테스트1','','Equip01','EA','','김건우',GETDATE())
,('P_Test02','테스트2','','Equip01','EA','','김건우',GETDATE())
,('P_Test03','테스트3','','Equip01','EA','','김건우',GETDATE())
,('P_Test04','테스트4','','Equip01','EA','','김건우',GETDATE())


--Create Lot--
delete from T1_CreateLot;
INSERT INTO [LTDB].[dbo].[T1_CreateLot] (
    [Code], [Amount1], [Amount2], [StockUnit1], [StockUnit2], [ActionTime], [ActionCode],
    [HisNum], [ProcessCode], [ItemCode], [Constructor], [RegDate], [Modifier], [ModDate], [ItemId], [ProcessId]
)
VALUES
    ('L_Test01', '50', '1', '상품1','대',GETDATE(), 1, 'Create', 'P_Test01', 'C_001', '김건우', GETDATE()),
    ('L_Test02', '50', '2', '상품1','대',GETDATE(), 1, 'Create', 'P_Test02', 'C_002', '김건우', GETDATE()),
    ('L_Test03', '50', '3', '상품2','대',GETDATE(), 1, 'Create', 'P_Test03', 'C_003', '김건우', GETDATE()),
    ('L_Test04', '50', '4', '상품2','대',GETDATE(), 1, 'Create', 'P_Test04', 'C_004', '김건우', GETDATE());


--입고내역

--출고내역
select * from T1_InBound;
select * from T1_OutBound;
select * from T1_WareHouse;
select * from T1_Account;
select * from T1_Item;
select * from T1_InBound;
select * from T1_OutBound;
select * from T1_MProcess;

select * from T1_Acount where name like '%테스트%'

select * from T1_LotHis
select * from T1_Item;

ALTER TABLE [LTDB].[dbo].[T1_Acount]
ADD DEFAULT (1) FOR [Authority]

insert into T1_LotHis(Code,Amount1,Amount2,ActionTime,ActionCode,HisNum,ProcessCode,ItemCode,Constructor,RegDate)
values('LT_C001',


--drop
drop table T1_Account;
drop table T1_Department
drop table T1_EquipHis;
drop table T1_Equipment;
drop table T1_InBound;
drop table T1_OutBound;
drop table T1_LotHis;
drop table T1_WareHouse;
drop table T1_CreateLot
drop table T1_Item
drop table T1_MProcess;
drop table T1_Factory;

