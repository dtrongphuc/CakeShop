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
		--(2,N'BÁNH TƯƠI NHÂN TRỨNG SỮA', 15000, N'Bánh tươi sử dụng nguyên liệu cao cấp. Vỏ bánh mềm mịn hòa quyện lớp nhân kem sữa thơm ngon.', '/Resource/Images/Products/banhtuoinhantrungsua1.jpg')
		--(3,N'BÁNH CUỘN SOCOLA MIẾNG',20000,N'Bánh cuộn socola miếng được xếp cuộn lại với nhau thành hình xoắn ốc, mỗi lớp cuộn, bánh lại phủ lên một lớp kem sữa. Với hương vị socola hòa quyện cùng lớp kem tươi hảo hạn', '/Resource/Images/Products/banhcuonsocolamieng1.jpg')
		--(4,N'BÁNH QUY VỪNG GIÒN', 15000, N'Bánh quy vừng giòn được làm từ nguyên liệu cao cấp. Bánh giòn tan, hương vị béo ngậy của bơ hoà quyện với vừng nướng.', '/Resource/Images/Products/banhquyvung1.jpg')
		--(1,N'Crown Cake', 720000,N'Điểm nhấn của Crown Birthday Cake chính là cách décor sang trọng, tinh tế nhưng không kém phần lộng lẫy. Thân bánh được trang trí theo tone màu lam với hiệu ứng chuyển sắc đậm nhạt dần, đính kèm những hạt ngọc trai trắng ngà – tượng trưng cho hình ảnh của dãi Ngân Hà huyền ảo. Phần trên bánh là chiếc vương miện đầy quyền uy và kiêu sa, thu hút mọi ánh nhìn ngay từ cái “chạm” mắt đầu tiên.', '/Resource/Images/Products/crowncake1.jpeg')
		--(1,N'The Swan Cake', 690000,N'“The Swan“ là chiếc bánh sinh nhật được lấy cảm hứng từ bộ môn nghệ thuật này. Điểm nhấn của bánh là cách decor đơn giản nhưng tinh tế với hai màu trắng – hồng pastel chủ đạo. Nổi bật trên nền bánh là hình ảnh nàng vũ công ballet với đôi cánh thiên nga trắng muốt, toát lên vẻ thanh thoát và duyên dáng.', '/Resource/Images/Products/swancake1.jpeg')
		--(3,N'BÁNH CHEESE CAKE',29000,N'Bánh Cheese Cake: Lấy nguồn cảm hứng từ xứ sở hoa Anh Đào, chiếc bánh thơm mùi phô mai nhưng không quá béo ngậy, phù hợp với khẩu vị của người Việt.', '/Resource/Images/Products/cheesecake1.jpg')
		--(2, N'SANDWICH CÁ NGỪ PHOMAI', 30000,N'Sandwich bao gồm nguyên liệu cá ngừ, phomai, sốt Mayonnaise và trứng gà, được hòa quyện với nhau tạo nên chiếc bánh sandwich cá ngừ phomai đầy hấp dẫn', '/Resource/Images/Products/sandwichcanguphomai1.jpg')
		
INSERT INTO SIZEPRODUCT
VALUES --(1, 'FREESIZE', 30)
		--(2,'S', 10), (2,'M', 10), (2,'L', 0)
		--(3, 'FREESIZE', 120)
		--(4, 'S' , 100), (4, 'M', 50), (4,'L', 120)
		--(5,'S', 200),(5,'M',300), (5,'L', 120)
		--(6,'FREESIZE',150)
		--(7,'S',400),(7,'M',700),(7,'L',1000)
		--(8,'FREESIZE',4000)
		--(9, 'S' , 100), (9, 'M', 50), (9,'L', 120)
		--(10,'S', 200),(10,'M',300), (10,'L', 120)
		--(11,'S',400),(11,'M',700),(11,'L',1000)
		--(12,'S',400),(12,'M',700),(12,'L',1000)
INSERT INTO IMAGES
VALUES --(1,'/Resource/Images/Products/banhquysua1.jpg'), (1,'/Resource/Images/Products/banhquysua2.jpg'), (1,'/Resource/Images/Products/banhquysua3.jpg'), (1,'/Resource/Images/Products/banhquysua4.jpg'), (1,'/Resource/Images/Products/banhquysua5.jpg')
		--(2, '/Resource/Images/Products/banhkemboston1.jpg'), (2, '/Resource/Images/Products/banhkemboston2.jpg'), (2, '/Resource/Images/Products/banhkemboston3.jpg'), (2, '/Resource/Images/Products/banhkemboston4.jpg'), (2, '/Resource/Images/Products/banhkemboston5.jpg')
		--(3,'/Resource/Images/Products/sandwichgiambong1.jpg'), (3,'/Resource/Images/Products/sandwichgiambong2.jpg'), (3,'/Resource/Images/Products/sandwichgiambong3.jpg'), (3,'/Resource/Images/Products/sandwichgiambong4.jpg'), (3,'/Resource/Images/Products/sandwichgiambong5.jpg')
		--(4,'/Resource/Images/Products/banhcuonkemtuoitraxanh1.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh2.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh3.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh4.jpg'), (4,'/Resource/Images/Products/banhcuonkemtuoitraxanh5.jpg')
		--(5,'/Resource/Images/Products/banhkemteddy2.jpg'),(5,'/Resource/Images/Products/banhkemteddy3.jpg'), (5,'/Resource/Images/Products/banhkemteddy4.jpg'), (5,'/Resource/Images/Products/banhkemteddy5.jpg')
		--(5,'/Resource/Images/Products/banhkemteddy.jpg')
		--(6,'/Resource/Images/Products/banhtuoinhantrungsua1.jpg'),(6,'/Resource/Images/Products/banhtuoinhantrungsua2.jpg'), (6,'/Resource/Images/Products/banhtuoinhantrungsua3.jpg'), (6,'/Resource/Images/Products/banhtuoinhantrungsua4.jpg'), (6,'/Resource/Images/Products/banhtuoinhantrungsua5.jpg')
		--(7,'/Resource/Images/Products/banhcuonsocolamieng1.jpg'),(7,'/Resource/Images/Products/banhcuonsocolamieng2.jpg'),(7,'/Resource/Images/Products/banhcuonsocolamieng3.jpg'),(7,'/Resource/Images/Products/banhcuonsocolamieng4.jpg'),(7,'/Resource/Images/Products/banhcuonsocolamieng5.jpg')
		--(8,'/Resource/Images/Products/banhquyvung1.jpg'),(8,'/Resource/Images/Products/banhquyvung2.jpg'),(8,'/Resource/Images/Products/banhquyvung3.jpg'),(8,'/Resource/Images/Products/banhquyvung4.jpg'),(8,'/Resource/Images/Products/banhquyvung5.jpg')
		--(9,'/Resource/Images/Products/crowncake1.jpeg'),(9,'/Resource/Images/Products/crowncake2.jpeg'),(9,'/Resource/Images/Products/crowncake3.jpeg')
		--(10,'/Resource/Images/Products/swancake1.jpeg'),(10,'/Resource/Images/Products/swancake2.png'), (10,'/Resource/Images/Products/swancake3.jpg'),(10,'/Resource/Images/Products/swancake4.jpg'),(10,'/Resource/Images/Products/swancake5.jpg')
		--(11,'/Resource/Images/Products/cheesecake1.jpg'),(11,'/Resource/Images/Products/cheesecake2.jpg'),(11,'/Resource/Images/Products/cheesecake3.jpg'),(11,'/Resource/Images/Products/cheesecake4.jpg'),(11,'/Resource/Images/Products/cheesecake5.jpg')
		--(12,'/Resource/Images/Products/sandwichcanguphomai1.jpg'),(12,'/Resource/Images/Products/sandwichcanguphomai2.jpg'),(12,'/Resource/Images/Products/sandwichcanguphomai3.jpg'),(12,'/Resource/Images/Products/sandwichcanguphomai4.jpg'),(12,'/Resource/Images/Products/sandwichcanguphomai5.jpg')
INSERT INTO ORDERS 
VALUES --(N'Lý Văn Đức', N'27 Phố Lợi, Phường Từ, Huyện Cường Châu Sơn La', 'Duc@gmail.com', N'Tên Bánh Kem là Chúc Kem xú tuổi mới học giỏi', 350000, 0 , '7/29/2020')
		--(N'Khoa Mạnh Vĩnh', N'690, Ấp Việt Cổ, Phường Vọng Nhậm, Huyện Ly Lâm Sóc Trăng', 'Vinh@gmail.com', N'sandwich cho nhiều giăm bông', 50000,1, '6/29/2020')
		--(N'Trương Trâm Ca',N'8340 Phố Viên, Xã Lâm Hán, Huyện BắcKiên Giang', 'Ca@gmail.com', N'Giao Hàng trước 12h30',315000,0,'5/23/2020')
		--(N'Hồng Phú Nghị', N'6316 Phố Tăng Văn Hiếu, Xã Phi Triết Sinh, Quận PhongHà Nội', 'nghi@gmail.com', N'Khi giao hàng gọi số điện thoại 0366565541', 395000,0 ,'3/25/2020')
		--(N'Điền Sơn Thời', N'468 Phố Liễu, Ấp Phụng Khang, Quận Thủy Hải Phòng', 'Thoi@gmail.com',NULL,160000,0,'9/30/2020')
		--(N'Khúc Kiết Ánh',N'549 Phố Phi Thanh Minh, Xã Ân, Huyện Bình Nam Quảng Nam','anh@gmail.com', NULL,500000,0,'2/26/2020')
		--(N'Tôn Thy Băng', N'04 Phố Trưng, Phường Lễ, Quận Ánh Hà Nam', 'bang@gmail.com', N'Lời Nhắn: Chúc em là ngươi tuyệt nhất trong đời anh, làm người yêu anh nhé.', 720000,1,'10/14/2020')
		--(N'Đậu Dạ Nga', N'026, Ấp Hiển Hình, Xã 3, Huyện Thảo Thái Bình', 'nga@gmail.com', N'Lời Nhắn: Con gái bố luôn xin nhất, tuổi mới mong con luôn khỏe và xin hơn.', 690000,1,'1/12/2020')
		--(N'Sơn Loan Lễ','1 Phố Giao Ngà Nhi, Xã 15, Quận Anh Sử, Đà Nẵng', 'le@gmail.com', NULL,152000,0,'4/4/2020')
		(N'Lã Bảo Hà', N'820 Phố Đào Thời Dinh, Phường Nhân, Huyện 2, Hà Nội', 'ha@gmail.com', NULL,210000,1,'3/25/2020')
	
INSERT INTO DETAILORDER 
VALUES	--(1,2,1,'M',350000)
		--(2,3,2,'FREESIZE',50000)
		--(3,5,1,'M',280000)
		--(3,1,1,'FREESIZE',35000)
		--(4,2,1,'S', 350000),
		--(4,6,3,'FREESIZE',45000)
		--(5,7,4,'M',80000),
		--(5,3,2,'FREESIZE',50000),
		--(5,6,2,'FREESIZE',30000)
		--(6,8,10,'FREESIZE',150000),
		--(6,2,1,'M',350000)
		--(7,9,1,'M',720000)
		--(8,10,1,'S',690000)
		--(9,11,3,'S',87000),
		--(9,6,1,'FREESIZE',15000),
		--(9,7,1,'S',20000),
		--(9,8,2,'FREESIZE',30000)
		(10,3,3,'FREESIZE',75000),
		(10,6,3,'FREESIZE', 45000),
		(10,12,3,'L', 90000)
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
select * from product

SELECT IDORDER,CUSTOMERNAME,ADDRESS,EMAIL, NOTE,TOTAL,STATUS, MONTH(DATE) AS 'MONTH' FROM ORDERS