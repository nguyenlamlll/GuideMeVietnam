create table CITY
(
	cityID smallint identity(1,1) not null primary key,
	cityName nvarchar(50),
	longitude decimal(10,6),
	latitude decimal(10,6),
	totalArea int,
	populationCity int
)

create table TRANSPORTATION
(
	tranID smallint identity(1,1) not null primary key,
	tranName nvarchar(50),
	detail ntext
)

create table REGION
(
	regionID smallint identity(1,1) not null primary key,
	regionName nvarchar(50)
)

create table PROVINCE
(
	provinceID smallint identity(1,1) not null primary key,
	provinceName nvarchar(50),
	longtitude decimal(10,6),
	latitude decimal(10,6),
	totalArea int,
	populationProvince int,
	cityID smallint foreign key references CITY(cityID),
	regionID smallint foreign key references REGION(regionID),
	tranID smallint foreign key references TRANSPORTATION(tranID)
)

create table ICON
(
	iconID smallint identity(1,1) not null primary key,
	iconSource nvarchar(100)
)

create table LOCATION_TYPE
(
	typeID smallint identity(1,1) not null primary key,
	typeName nvarchar(50),
	iconID smallint foreign key references ICON(iconID)
)

create table LOCATIONS
(
	locationID smallint identity(1,1) not null primary key,
	locationName nvarchar(50),
	locationAddress nvarchar(100),
	phoneNumber char(20),
	priceMin money,
	priceMax money,
	website nvarchar(50),
	longitude decimal(10,6),
	latitude decimal(10,6),
	typeID smallint foreign key references LOCATION_TYPE(typeID),
	provinceID smallint foreign key references PROVINCE(provinceID)
)

create table ARTICLE
(
	articleID smallint identity(1,1) not null primary key,
	content ntext,
	locationID smallint foreign key references LOCATIONS(locationID)
)

create table IMAGES
(
	imageID smallint identity(1,1) not null primary key,
	imageSource nvarchar(100),
	articleID smallint foreign key references ARTICLE(articleID)
)

create table VIDEO
(
	videoID smallint identity(1,1) not null primary key,
	videoName nvarchar(50),
	videoSource nvarchar(100),
	locationID smallint foreign key references LOCATIONS(locationID)
)

create table SCHEDULE_TEMPLATE
(
	scheduleID smallint identity(1,1) not null primary key,
	scheduleDetail ntext,
	expectedCharge money,
	locationID smallint foreign key references LOCATIONS(locationID)
)

create table USERS
(
	userID smallint identity(1,1) not null primary key,
	userName nvarchar(50),
	email nvarchar(50)
)

create table ACCOUNT
(
	userID smallint foreign key references USERS(userID),
	id char(20) not null,
	pass varchar(50) not null,
	primary key(id, pass) 
)

create table APPRECIATION
(
	appreciaID smallint identity(1,1) not null primary key,
	userID smallint foreign key references USERS(userID),
	locationID smallint foreign key references LOCATIONS(locationID),
	numStar smallint,
	appreciaSubject nvarchar(100),
	content ntext
)

create table PLAN_TRIP
(
	planID smallint identity(1,1) not null primary key,
	planName nvarchar(50),
	detail ntext,
	userID smallint foreign key references USERS(userID)
)

create table MAP
(
	mapID smallint identity(1,1) not null primary key,
	mapName nvarchar(50),
	longtitude decimal(10,6),
	latitude decimal(10,6)
)
