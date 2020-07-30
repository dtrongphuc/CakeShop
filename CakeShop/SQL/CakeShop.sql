CREATE TABLE CATEGORY
(
	IDCATEGORY INT NOT NULL IDENTITY,
	CATEGORYNAME NVARCHAR(100)

	CONSTRAINT PK_CATEGORY
	PRIMARY KEY (IDCATEGORY)
)

CREATE TABLE PRODUCT
(
	IDPRODUCT INT NOT NULL IDENTITY,
	IDCATEGORY INT,
	PRODUCTNAME NVARCHAR(MAX),
	PRICE INT,
	DESCRIPTION NVARCHAR(MAX),
	IMAGE VARCHAR(MAX),

	 CONSTRAINT PK_PRODUCT
	PRIMARY KEY (IDPRODUCT)
)



CREATE TABLE SIZEPRODUCT
(
	IDPRODUCT INT,
	SIZE VARCHAR(10),
	QUANTITY INT,

	CONSTRAINT PK_SIZEPRODUCT
	PRIMARY KEY (IDPRODUCT,SIZE)

)

CREATE TABLE ORDERS
(
	IDORDER INT NOT NULL IDENTITY,
	CUSTOMERNAME NVARCHAR(100),
	ADDRESS NVARCHAR(MAX),
	EMAIL VARCHAR(100),
	NOTE NVARCHAR(MAX),
	TOTAL INT,
	STATUS INT,
	DATE VARCHAR(10)

	CONSTRAINT PK_ORDER
	PRIMARY KEY (IDORDER)
)

CREATE TABLE DETAILORDER
(
	IDORDER INT,
	IDPRODUCT INT,
	QUATITY INT,
	SIZE VARCHAR(10),
	TOTALPRICE INT
	
	CONSTRAINT PK_DETAILORDER
	PRIMARY KEY (IDORDER,IDPRODUCT,SIZE)
)

CREATE TABLE IMAGES
(
	IDPRODUCT INT,
	IMAGE VARCHAR(MAX)
)

ALTER TABLE PRODUCT ADD CONSTRAINT FK_PRODUCT_CATEGORY FOREIGN KEY(IDCATEGORY) REFERENCES CATEGORY(IDCATEGORY)

ALTER TABLE SIZEPRODUCT ADD CONSTRAINT FK_SIZEPRODUCT_PRODUCT FOREIGN KEY(IDPRODUCT) REFERENCES PRODUCT(IDPRODUCT)

ALTER TABLE DETAILORDER ADD CONSTRAINT FK_DETAILPRODUCT_ORDERS FOREIGN KEY(IDORDER) REFERENCES ORDERS(IDORDER)

ALTER TABLE DETAILORDER ADD CONSTRAINT FK_DETAILPRODUCT_PRODUCT FOREIGN KEY(IDPRODUCT) REFERENCES PRODUCT(IDPRODUCT)

ALTER TABLE DETAILORDER ADD CONSTRAINT FK_DETAILORDER_SIZEPRODUCT FOREIGN KEY(IDPRODUCT,SIZE) REFERENCES SIZEPRODUCT(IDPRODUCT,SIZE)

ALTER TABLE IMAGES ADD CONSTRAINT FK_IMAGES_PRODUCT FOREIGN KEY (IDPRODUCT) REFERENCES  PRODUCT(IDPRODUCT)

alter table DETAILORDER drop constraint FK_DETAILPRODUCT_PRODUCT

drop table DETAILORDER

INSERT INTO CATEGORY 
VALUES	(N'Bánh Kem Tươi'), (N'Bánh Mỳ Tươi'), (N'Bánh GaTo'), (N'Bánh Quy')

INSERT INTO PRODUCT
VALUES 
		--(4,N'BÁNH QUY BƠ DỪA',35000, N'Bánh quy bơ dừa được làm từ nguyên liệu cao cấp. Bánh giòn xốp, hương thơm béo của dừa hoà quyện với vị ngậy từ bơ. Bánh quy phù hợp với buổi tiệc trà và cà phê.','/Resource/Images/Products/banhquysua1.jpg')
		--(1,N'BÁNH KEM BOSTON CHOCOLATE', 350000, N'Bánh Boston Chocolate Fresh Garden có cốt bánh socola 3 lớp nhân kem socola, mặt bánh phủ socola, trang trí macaron và socola bi', '/Resource/Images/Products/banhkemboston1.jpg')
		--(2,N'SANDWICH GIĂM BÔNG', 25000, N'Sandwich giăm bông được làm từ bột mì của bánh gối và được kết hợp giữa giăm bông, xà lách và cà chua cùng với sốt mayonnaise. Các nguyên liệu hòa quyện làm một tạo thành chiếc sandwich thơm ngon và béo ngậy', '/Resource/Images/Products/sandwichgiambong1.jpg')
		--(3,N'BÁNH CUỘN KEM TƯƠI TRÀ XANH', 30000, N'Bánh cuộn kem tươi: Món ăn nhẹ phổ biến và ưa thích của mỗi gia đình người Nhật, nhân kem tươi béo ngậy cùng lớp bông lan mềm mịn sẽ khác hẳn với các loại nhân kem thông thường. Fresh Garden có hai phiên bản: Bánh cuộn vani và trà xanh cho bạn lựa chọn.', '/Resource/Images/Products/banhcuonkemtuoitraxanh1.jpg')
		--(1,N'BÁNH KEM TEDDY BEAR',280000,N'Nằm trong BTS bánh kem ngộ nghĩnh từ Fresh Garden, với cốt bánh socola 4 lớp với lớp nhân mứt táo đặc biệt, lớp kem socola cùng với bàn tay khéo léo của người thợ đã tạo hình nên chiếc bánh kem hình mặt chú gấu vô cùng dễ thương và bắt mắt.', '/Resource/Images/Products/banhkemteddy.jpg')



INSERT INTO SIZEPRODUCT
VALUES --(1, 'FREESIZE', 30)
		--(2,'S', 10), (2,'M', 10), (2,'L', 0)
		--(3, 'FREESIZE', 120)
		--(4, 'S' , 100), (4, 'M', 50), (4,'L', 120)
		(5,'S', 200),(5,'M',300), (5,'L', 120)


INSERT INTO IMAGES
VALUES --(1,'/Resource/Images/Products/banhquysua1.jpg'), (1,'/Resource/Images/Products/banhquysua2.jpg'), (1,'/Resource/Images/Products/banhquysua3.jpg'), (1,'/Resource/Images/Products/banhquysua4.jpg'), (1,'/Resource/Images/Products/banhquysua5.jpg')
		--(2, '/Resource/Images/Products/banhkemboston1.jpg'), (2, '/Resource/Images/Products/banhkemboston2.jpg'), (2, '/Resource/Images/Products/banhkemboston3.jpg'), (2, '/Resource/Images/Products/banhkemboston4.jpg'), (2, '/Resource/Images/Products/banhkemboston5.jpg')
		--(3,'/Resource/Images/Products/sandwichgiambong1.jpg'), (3,'/Resource/Images/Products/sandwichgiambong2.jpg'), (3,'/Resource/Images/Products/sandwichgiambong3.jpg'), (3,'/Resource/Images/Products/sandwichgiambong4.jpg'), (3,'/Resource/Images/Products/sandwichgiambong5.jpg')
		--(4,'/Resource/Images/Products/banhcuonkemtuoitraxanh1.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh2.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh3.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh4.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh5.jpg')
		--(5,'/Resource/Images/Products/banhkemteddy2.jpg'),(5,'/Resource/Images/Products/banhkemteddy3.jpg'), (5,'/Resource/Images/Products/banhkemteddy4.jpg'), (5,'/Resource/Images/Products/banhkemteddy5.jpg')
		--(5,'/Resource/Images/Products/banhkemteddy.jpg')

select * from product

INSERT INTO ORDERS 
VALUES --(N'Lý Văn Đức', N'27 Phố Lợi, Phường Từ, Huyện Cường Châu Sơn La', 'Duc@gmail.com', N'Tên Bánh Kem là Chúc Kem xú tuổi mới học giỏi', 350000, 0 , '7/29/2020')
		--(N'Khoa Mạnh Vĩnh', N'690, Ấp Việt Cổ, Phường Vọng Nhậm, Huyện Ly Lâm Sóc Trăng', 'Vinh@gmail.com', N'sandwich cho nhiều giăm bông', 50000,1, '6/29/2020')

INSERT INTO DETAILORDER 
VALUES	--(1,2,1,'M',350000)
		--(2,3,2,'FREESIZE',50000)


CREATE TABLE DETAILORDER
(
	IDORDER INT,
	IDPRODUCT INT,
	QUATITY INT,
	SIZE VARCHAR(10),
	TOTALPRICE INT
	
	CONSTRAINT PK_DETAILORDER
	PRIMARY KEY (IDORDER,IDPRODUCT,SIZE)
)

SELECT IDORDER,CUSTOMERNAME,ADDRESS,EMAIL, NOTE,TOTAL,STATUS, MONTH(DATE) AS 'MONTH' FROM ORDERS