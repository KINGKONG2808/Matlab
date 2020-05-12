create database QUANLYBANHANGcustom

use QUANLYBANHANGcustom
go
create table SanPham(
	ma_sp nvarchar(200) primary key not null, 
	ten_sp nvarchar(200), 
	ma_loai int, 
	don_gia float)
go
create table LoaiSP (
	ma_loai int primary key not null, 
	ten_loai nvarchar(200)
)
go

insert into SanPham values ('001', 'may tinh', 1, 1000)
insert into SanPham values ('002', 'but bi', 2, 2000)
insert into SanPham values ('003', 'keo dan', 3, 1000)
insert into SanPham values ('004', 'keo deo', 2, 3000)
insert into SanPham values ('005', 'keo cao su', 1, 4000)
insert into SanPham values ('006', 'bang dinh', 3, 1000)
insert into LoaiSP values (1, 'dien tu')
insert into LoaiSP values (2, 'gia dung')
insert into LoaiSP values (3, 'thuc an')


create proc nhap (@masp nvarchar(200), @tensp nvarchar(200), @maloai int, @dongia float)
as
	begin
		insert into SanPham values (@masp, @tensp, @maloai, @dongia)
	end

exec nhap '007', 'quan ao', 2, 5000

select * from SanPham