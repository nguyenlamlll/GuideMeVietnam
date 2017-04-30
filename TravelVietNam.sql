create table REGION
(
	regionID smallint identity(1,1) not null primary key,
	regionName nvarchar(50)
);

create table PROVINCE
(
	provinceID smallint identity(1,1) not null primary key,
	provinceName nvarchar(50),
	longtitude decimal(10,6),
	latitude decimal(10,6),
	totalArea real,
	populationProvince real,
	regionID smallint,
    foreign key(regionID) references REGION(regionID)
);

create table CITY
(
	cityID smallint identity(1,1) not null primary key,
	cityName nvarchar(50),
	longitude decimal(10,6),
	latitude decimal(10,6),
	totalArea real,
	populationCity real,
	provinceID smallint,
    foreign key(provinceID) references PROVINCE(provinceID)
);

create table ICON
(
	iconID smallint identity(1,1) not null primary key,
	iconSource nvarchar(100)
);

create table LOCATION_TYPE
(
	typeID smallint identity(1,1) not null primary key,
	typeName nvarchar(50),
	iconID smallint,
    foreign key(iconID) references ICON(iconID)
);

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
	typeID smallint,
	provinceID smallint,
	foreign key(typeID) references LOCATION_TYPE(typeID),	
	foreign key(provinceID) references PROVINCE(provinceID)
);

create table TRANSPORTATION
(
	tranID smallint identity(1,1) not null primary key,
	tranName nvarchar(50),
	detail ntext,
	locationID smallint,
    foreign key(locationID) references LOCATIONS(locationID)
);

create table ARTICLE
(
	articleID smallint identity(1,1) not null primary key,
	content ntext,
	locationID smallint,
    foreign key(locationID) references LOCATIONS(locationID)
);

create table IMAGES
(
	imageID smallint identity(1,1) not null primary key,
	imageSource nvarchar(100),
	articleID smallint,
    foreign key(articleID) references ARTICLE(articleID)
);

create table VIDEO
(
	videoID smallint identity(1,1) not null primary key,
	videoName nvarchar(50),
	videoSource nvarchar(100),
	locationID smallint,
    foreign key(locationID) references LOCATIONS(locationID)
);

create table SCHEDULE_TEMPLATE
(
	scheduleID smallint identity(1,1) not null primary key,
	scheduleDetail ntext,
	expectedCharge money,
	locationID smallint,
    foreign key(locationID) references LOCATIONS(locationID)
);

create table ACCOUNT
(
	accountID smallint identity(1,1) not null,
	id char(20) not null,
	pass varchar(50) not null,
	primary key(id, pass, accountID)
);

create table USERS
(
	userID smallint identity(1,1) not null primary key,
	userName nvarchar(50),
	email nvarchar(50),
    accountID smallint,
    foreign key(accountID) references ACCOUNT(accountID)
);

create table APPRECIATION
(
	appreciaID smallint identity(1,1) not null primary key,
	userID smallint,
	locationID smallint, 
	numStar smallint,
	appreciaSubject nvarchar(100),
	content ntext,
    foreign key(userID) references USERS(userID),
    foreign key(locationID) references LOCATIONS(locationID)
);

create table PLAN_TRIP
(
	planID smallint identity(1,1) not null primary key,
	planName nvarchar(50),
	detail ntext,
	userID smallint, 
	foreign key(userID) references USERS(userID)
);

create table MAP
(
	mapID smallint identity(1,1) not null primary key,
	mapName nvarchar(50),
	longtitude decimal(10,6),
	latitude decimal(10,6)
);

