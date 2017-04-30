using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel.DBModels;

namespace Source.DBModels
{
    public static class InitData
    {
        public static void Init()
        {
            using (var db = new VietTravel.VietTravelDBContext())
            {
                //Add values into ACCOUNTs
                db.ACCOUNTs.Add(new ACCOUNT() { userName = "leekhai18", pass = "123" });
                db.SaveChanges();

                //Add values into REGION
                db.REGIONs.Add(new REGION() { regionName = "Nothern VietNam" });
                db.REGIONs.Add(new REGION() { regionName = "Central VietNam" });
                db.REGIONs.Add(new REGION() { regionName = "Southern VietNam" });
                db.SaveChanges();

                //Add values into PROVINCE
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Ha Noi", latitude = 21.028919f, longtitude = 105.854622f, totalArea = 1285, populationProvince = 7588, regionID = 1 }); db.PROVINCEs.Add(new PROVINCE() { provinceName = "Ha Noi", latitude = 21.028919f, longtitude = 105.854622f, totalArea = 1285, populationProvince = 7588, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Lao Cai", latitude = 22.504671f, longtitude = 103.965607f, totalArea = 2465, populationProvince = 656.9f, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Quang Ninh", latitude = 21.264654f, longtitude = 107.263397f, totalArea = 2356, populationProvince = 1199, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Hai Phong", latitude = 20.861670f, longtitude = 106.681831f, totalArea = 1527, populationProvince = 2103, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Ninh Binh", latitude = 20.224667f, longtitude = 105.901047f, totalArea = 534, populationProvince = 927, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Ha Giang", latitude = 22.833109f, longtitude = 104.983994f, totalArea = 3068, populationProvince = 771.2f, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Nam Dinh", latitude = 20.422930f, longtitude = 106.173630f, totalArea = 647, populationProvince = 1934, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Thai Binh", latitude = 20.445278f, longtitude = 106.341850f, totalArea = 595, populationProvince = 1787, regionID = 1 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Binh Dinh", latitude = 14.121881f, longtitude = 108.951126f, totalArea = 2326, populationProvince = 1510, regionID = 2 });
                db.PROVINCEs.Add(new PROVINCE() { provinceName = "Ho Chi Minh", latitude = 10.769444f, longtitude = 106.681944f, totalArea = 2095.6f, populationProvince = 8244.4f, regionID = 3 });
                db.SaveChanges();

                //Add values into CITY
                db.CITies.Add(new CITY() { cityName = "Tp. Lao Cai", latitude = 22.476940f, longitude = 103.975487f, totalArea = 88.68f, populationCity = 98.363f, provinceID = 2 });
                db.CITies.Add(new CITY() { cityName = "Tp. Ha Long", latitude = 20.950670f, longitude = 107.074532f, totalArea = 105, populationCity = 221.58f, provinceID = 3 });
                db.CITies.Add(new CITY() { cityName = "Tp. Uong Bi", latitude = 21.036455f, longitude = 106.781563f, totalArea = 98.96f, populationCity = 170, provinceID = 3 });
                db.CITies.Add(new CITY() { cityName = "Tp. Cam Pha", latitude = 21.013145f, longitude = 107.292549f, totalArea = 187.8f, populationCity = 203.435f, provinceID = 3 });
                db.CITies.Add(new CITY() { cityName = "Tp. Ninh Binh", latitude = 20.256769f, longitude = 105.981483f, totalArea = 18.67f, populationCity = 160.166f, provinceID = 5 });
                db.CITies.Add(new CITY() { cityName = "Tp. Ha Giang", latitude = 22.830570f, longitude = 104.985519f, totalArea = 16.61f, populationCity = 3.515f, provinceID = 6 });
                db.CITies.Add(new CITY() { cityName = "Tp. Nam Dinh", latitude = 20.427931f, longitude = 106.171509f, totalArea = 17.91f, populationCity = 380.069f, provinceID = 7 });
                db.CITies.Add(new CITY() { cityName = "Tp. Thai Binh", latitude = 20.451691f, longitude = 106.347633f, totalArea = 26.14f, populationCity = 268.167f, provinceID = 8 });
                db.CITies.Add(new CITY() { cityName = "Tp. Quy Nhon", latitude = 13.769740f, longitude = 109.232224f, totalArea = 109.7f, populationCity = 537.32f, provinceID = 9 });
                db.SaveChanges();

                //Add values into LOCATION_TYPE
                db.LOCATION_TYPE.Add(new LOCATION_TYPE() { typeName = "Discovery" });
                db.LOCATION_TYPE.Add(new LOCATION_TYPE() { typeName = "Eating" });
                db.LOCATION_TYPE.Add(new LOCATION_TYPE() { typeName = "Dwelling" });
                db.SaveChanges();

                //Add values into LOCATION in HCM
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Starlight Bridge", locationAddress = "Phu My Hung, District 7, Ho Chi Minh City", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Bitexco financial tower", locationAddress = "02 Hai Trieu Street, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 39156868", website = "http://www.bitexcofinancialtower.com/", longitude = 106.704545f, latitude = 10.771845f, provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Turtle Lake", locationAddress = "Ward 6, District 3, Ho Chi Minh City", longitude = 106.695833f, latitude = 10.782500f, provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Nguyen Hue Walking Street", locationAddress = "Nguyen Hue Street, Ben Nghe Ward, District 1, Ho Chi Minh City", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Dam Sen Park", locationAddress = "03 Hoa Binh Street, Ward 3, District 11, Ho Chi Minh City", phoneNumber = "+84 8 3963 3593", priceMin = 100000, priceMax = 300000, website = "http://damsenpark.com.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Independence Palace", locationAddress = "135 Nam Ky Khoi Nghia, District 1, Ho Chi Minh City", phoneNumber = "+84 8 3822 3652", priceMin = 20000, priceMax = 40000, website = "https://www.dinhdoclap.gov.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 1, locationName = "Ben Thanh Market", locationAddress = "Le Loi Street, Ben Thanh Ward, District 1, Ho Chi Minh City", website = "http://chobenthanh.org.vn", longitude = 106.698006f, latitude = 10.772449f, provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Pancakes Dinh Cong Trang", locationAddress = "46 Dinh Cong Trang Street, Tan Dinh Ward, District 1, Ho CHi Minh City", phoneNumber = "08 3824 1110", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "LovEat", locationAddress = "29 Hai Trieu, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 6260 2727", website = "http://loveat.com.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Hang Duong Restaurant", locationAddress = "224 No.48 Street, Ward 5, District 4, Ho Chi Minh City", phoneNumber = "+84 8 3826 4439", website = "http://Hangduongquan.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Sai Gon Grill", locationAddress = "91 Pasteur Street, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 91 662 26 62", website = "http://Saigongrill.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Pendolasco", locationAddress = "87 Nguyen Hue Street, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 3821 8181", website = "http://pendolasco.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Rom BBQ Restaurant", locationAddress = "2 Luu Van Lang Street, Ben Thanh Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 3822 0060", website = "http://rombbq.com.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Tan Cang restaurant", locationAddress = "100A Ung Van Khiem Street, Ward 25, Binh Thanh District, Ho Chi Minh City", phoneNumber = "+84 8 3512 8775", website = "http://tancang-resort.com", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 2, locationName = "Monsoon", locationAddress = "1 Cao Ba Nha, Nguyen Cu Trinh Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 6290 8899", website = "http://marry.vn", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 3, locationName = "Villa SaiGon River", locationAddress = "197/2 Nguyen Van Huong street, Thao Dien ward, District 2, Ho Chi Minh City", phoneNumber = "+84 8 3744 6090", website = "http://villasong.com", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 3, locationName = "The Reverie Sai Gon", locationAddress = "22-36 Nguyen Hue Boulevard, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 3823 6688", website = "http://thereveriesaigon.com", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 3, locationName = "Intercontinental Asiana Sai Gon", locationAddress = "Hai Ba Trung Street, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 3520 9999", website = "http://ihg.com", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 3, locationName = "Park Hyatt Sai Gon", locationAddress = "2 Cong Truong Lam Son, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "+84 8 3824 1234", website = "http://saigon.park.hyatt.com", provinceID = 10 });
                db.LOCATIONS.Add(new LOCATION() { typeID = 3, locationName = "Rex Hotel", locationAddress = "141 Nguyen Hue Street, Ben Nghe Ward, District 1, Ho Chi Minh City", phoneNumber = "08 3829 2185", website = "http://rexhotelvietnam.com", provinceID = 10 });
                db.SaveChanges();

                //Add values into ARTICLE in HCM
                db.ARTICLEs.Add(new ARTICLE() { locationID = 1, content = "Starlight Bridge is the only pedestrian bridge to see and is the first pedestrian bridge in Vietnam. The bridge is located in Phu My Hung new urban area, District 7, Ho Chi Minh City [1]. It crosses over the canopies connecting the Crescent and Dao canals with a total investment of about 50 billions dong. This is a place to visit, an ideal place for many people in love." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 2, content = "The tower was designed by Carlos Zapata, Design Principal and Founder of Carlos Zapata Studio (www.cz-studio.com), with French company AREP as architect of record. Designer Zapata, who was born in Venezuela but is based in New York City, drew inspiration for this skyscraper's unique shape from Vietnam's national flower, the Lotus.  The tower was officially inaugurated on October 31, 2010. In 2013, CNN.com named the Bitexco Financial Tower one of the 25 Great Skyscraper Icons of Construction. And in 2015, Thrillist.com named the Bitexco Financial Tower the #2 Coolest Skyscraper in the World." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 3, content = "Located at the middle of Pham Ngoc Thach Street, Turtle Lake is a traffic roundabout of Pham Ngoc Thach Street with Tran Cao Van and Vo Van Tan Street. Turtle Lake attracts the tourists not only its location on the main street in the center of Saigon, but also its unique combination between Eastern and Western in architecture. Moreover, it was one of the symbols of this city that were built before 1975 and still stays nearly the same until today." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 4, content = "In 2015, Ho Chi Minh authority inaugurated Nguyen Hue walking street work with the length of 670 meters, width of 64 meters. Everyday, there are thousands of people coming to this places for visiting, playing, taking photos." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 5, content = "The park comprises 30 areas: an electronic games zone, folk tales theater, antique castle, square, small west lake, Nam Tu royal garden, rock garden, and water palace, dancing island, sea life center, subaquatic puppet theater, ancient Giac Vien pagoda, butterfly garden, fishing area, ky long display zone, tea store, adventure games zone, swan lake, horse’s gallop lake, western flower garden, ancient Rome-themed square, cultural square, water musical scene, bowling area, sport services area, crayfish fishing lake, Thuy Ta restaurant, children's play area, picture lamps, nine fragment edge, Monorail station, and Monorail track." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 6, content = "Independence Palace (Dinh Độc Lập), also known as Reunification Palace (Vietnamese: Dinh Thống Nhất), built on the site of the former Norodom Palace, is a landmark in Ho Chi Minh City, Vietnam. It was designed by architect Ngô Vi?t Th? and was the home and workplace of the President of South Vietnam during the Vietnam War. It was the site of the end of the Vietnam War during the Fall of Saigon on April 30, 1975, when a North Vietnamese Army tank crashed through its gates." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 7, content = "The Central Market of Hồ Chí Minh City it now serves not only the locals for fruits, vegetables and dry goods, but also the many welcome visitors to our land.  Inside Chợ Bến Thành are many souvenirs, T-Shirts and other garments as well as traditional handicrafts including lacquerware and embroidery.  Different textiles in famous Vietnamese and Asian styles as well as western styles. Fabric is also available to buy by the meter to take home." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 8, content = "46A pancake is probably a long-standing pancake shop in Saigon, because of the temptation of banh xeo here. The restaurant attracts a lot of foreign visitors, at any time can meet some foreign guests to enjoy delicious pancakes." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 9, content = "LovEat will bring you the cuisine of Italy and you will not be able to resist the romantic space here. Not only charming in each dish, LovEat also bring diners new space, luxury in accordance with Italian style." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 10, content = "Mentioning the romantic dining places in Saigon will not be lacking in Hang Duong Restauant. Those customers who have passion for riverside cuisine can not be ignored Hang Duong Quan. The fish that the restaurant will take you from surprise to surprise, big fish and have more than 100 pounds of weight like grouper.  A romantic dinner at the restaurant will make you remember forever, call the wine service because you will be visiting the wine cellar of the restaurant." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 11, content = "You will have a romantic dinner with wide space, visibility covering the whole city from above. Good food, reasonable price, barbecue taste unforgettable memory will make you remember forever. This is one of the romantic eating places in Saigon." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 12, content = "The fine wines from Italy and the countries of the world are created by the Pendolasco Restaurant, where you can choose the wine you like. The meal will add to the pungent taste of fine wine. The food here also specializes in Italian cuisine." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 13, content = "Rom BBQ is located on the top floor of Thanh The Plaza building, you can enjoy the grill, hot pot, flavor salad. Space fairy, beautiful, romantic, you will have great time when dining at this romantic eating place in Saigon." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 14, content = "When you dine at Tan Cang Restaurant you will see the entire Saigon River dreaming. The dishes bring a sense of water, plus cool air, relax themselves after stressful working hours. You can go with a family member or accompany a loved one." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 15, content = "With its elegant design and elegance, Monsoon impresses with the diners' bistro style garden villas. Although not space is too large but the design is beautiful, luxurious and noble left the impression hard to fade in the hearts come here." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 16, content = "Villa Song Saigon is a lovely boutique hotel with 23 unique, luxuriously appointed rooms and suites, which is located in District 2, Ho Chi Minh City, along the banks of the Saigon River. No two rooms are the same." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 17, content = "The Reverie Saigon has debuted as the most spectacularly extravagant hotel in Vietnam and as the one and only member property of The Leading Hotels of the World in all of Ho Chi Minh City. Taking pride of place on the topmost floors of the landmark Times Square Building in prestigious District 1, the much-lauded hotel presents world-class hospitality with its impeccable service and its unique celebration of haute Italian design and inimitable luxury." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 18, content = "As the world’s first international luxury hotel brand, InterContinental Hotels & Resorts has been pioneering travel across the globe for over 70 years now. We’re proud to share both international know-how and local cultural wisdom with our guests at every one of our hotels — from historic buildings to city landmarks and immersive resorts." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 19, content = "Discover the urban luxury with combination of sophisticated design, handcrafted details and modern-day comforts at Park Hyatt Saigon. You will enjoy the world-class bar and best restaurants in Ho Chi Minh City together with a tranquil spa. Park Hyatt Saigon looks forward to welcoming you with warm, discreet and dignified service for the ultimate relaxed and personalised luxury." });
                db.ARTICLEs.Add(new ARTICLE() { locationID = 20, content = "Strategically located at the best of downtown Saigon, the Rex Hotel is a luxury 5 stars hotel heritage dating back to early 20th century when it was originally opened as a French garage. For over 80 years, as a landmark, as well as a witness of the ups and downs of the city’s history, the Rex Hotel was rebuilt to become one of the city’s most incredible addresses. It prides itself to offer guests many high-class facilities including 286 individually designed guestrooms, a range of function & meeting room’s ideal for wedding, business or events, the luxurious spa, and four in-house restaurants, cafe and bar." });
                db.SaveChanges();

                //Add values into IMAGE in HCM ../Assets/Images/Provinces/SaiGon/abc.xyz
                db.IMAGES.Add(new IMAGE() { imageSource = "StarlightBridge0.png", articleID = 1 });
                db.IMAGES.Add(new IMAGE() { imageSource = "StarlightBridge1.png", articleID = 1 });
                db.IMAGES.Add(new IMAGE() { imageSource = "StarlightBridge2.png", articleID = 1 });
                db.IMAGES.Add(new IMAGE() { imageSource = "BitexcoTower0.jpg", articleID = 2 });
                db.IMAGES.Add(new IMAGE() { imageSource = "BitexcoTower1.jpg", articleID = 2 });
                db.IMAGES.Add(new IMAGE() { imageSource = "BitexcoTower2.jpg", articleID = 2 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TurtleLake0.jpg", articleID = 3 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TurtleLake1.jpg", articleID = 3 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TurtleLake2.jpg", articleID = 3 });
                db.IMAGES.Add(new IMAGE() { imageSource = "NguyenHueSt0.jpg", articleID = 4 });
                db.IMAGES.Add(new IMAGE() { imageSource = "NguyenHueSt1.jpg", articleID = 4 });
                db.IMAGES.Add(new IMAGE() { imageSource = "NguyenHueSt2.jpg", articleID = 4 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Damsen0.jpg", articleID = 5 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Damsen1.jpg", articleID = 5 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Damsen2.jpg", articleID = 5 });
                db.IMAGES.Add(new IMAGE() { imageSource = "IndependencePalace0.jpg", articleID = 6 });
                db.IMAGES.Add(new IMAGE() { imageSource = "IndependencePalace1.jpg", articleID = 6 });
                db.IMAGES.Add(new IMAGE() { imageSource = "IndependencePalace2.jpg", articleID = 6 });
                db.IMAGES.Add(new IMAGE() { imageSource = "BenThanh0.jpg", articleID = 7 });
                db.IMAGES.Add(new IMAGE() { imageSource = "BenThanh1.jpg", articleID = 7 });
                db.IMAGES.Add(new IMAGE() { imageSource = "BenThanh2.jpg", articleID = 7 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Pancakes0.jpg", articleID = 8 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Pancakes1.jpg", articleID = 8 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Pancakes2.jpg", articleID = 8 });
                db.IMAGES.Add(new IMAGE() { imageSource = "LovEat0.jpg", articleID = 9 });
                db.IMAGES.Add(new IMAGE() { imageSource = "LovEat1.jpg", articleID = 9 });
                db.IMAGES.Add(new IMAGE() { imageSource = "LovEat2.jpg", articleID = 9 });
                db.IMAGES.Add(new IMAGE() { imageSource = "HangDuongRestaurant0.jpg", articleID = 10 });
                db.IMAGES.Add(new IMAGE() { imageSource = "HangDuongRestaurant1.jpg", articleID = 10 });
                db.IMAGES.Add(new IMAGE() { imageSource = "HangDuongRestaurant2.jpg", articleID = 10 });
                db.IMAGES.Add(new IMAGE() { imageSource = "SaigonGrill0.jpg", articleID = 11 });
                db.IMAGES.Add(new IMAGE() { imageSource = "SaigonGrill1.jpg", articleID = 11 });
                db.IMAGES.Add(new IMAGE() { imageSource = "SaigonGrill2.jpg", articleID = 11 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Pendolasco0.jpg", articleID = 12 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Pendolasco1.jpg", articleID = 12 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Pendolasco2.jpg", articleID = 12 });
                db.IMAGES.Add(new IMAGE() { imageSource = "RomBBQ0.jpg", articleID = 13 });
                db.IMAGES.Add(new IMAGE() { imageSource = "RomBBQ1.jpg", articleID = 13 });
                db.IMAGES.Add(new IMAGE() { imageSource = "RomBBQ2.jpg", articleID = 13 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TanCangRestaurant0.jpg", articleID = 14 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TanCangRestaurant1.jpg", articleID = 14 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TanCangRestaurant2.jpg", articleID = 14 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Monsoon0.jpg", articleID = 15 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Monsoon1.jpg", articleID = 15 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Monsoon2.jpg", articleID = 15 });
                db.IMAGES.Add(new IMAGE() { imageSource = "VillaSgRiver0.jpg", articleID = 16 });
                db.IMAGES.Add(new IMAGE() { imageSource = "VillaSgRiver1.jpg", articleID = 16 });
                db.IMAGES.Add(new IMAGE() { imageSource = "VillaSgRiver2.jpg", articleID = 16 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TheReverieSaiGon0.jpg", articleID = 17 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TheReverieSaiGon1.jpg", articleID = 17 });
                db.IMAGES.Add(new IMAGE() { imageSource = "TheReverieSaiGon2.jpg", articleID = 17 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Intercontinental0.jpg", articleID = 18 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Intercontinental1.jpg", articleID = 18 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Intercontinental2.jpg", articleID = 18 });
                db.IMAGES.Add(new IMAGE() { imageSource = "ParkHyatt0.jpg", articleID = 19 });
                db.IMAGES.Add(new IMAGE() { imageSource = "ParkHyatt1.jpg", articleID = 19 });
                db.IMAGES.Add(new IMAGE() { imageSource = "ParkHyatt2.jpg", articleID = 19 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Rexhotel0.jpg", articleID = 20 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Rexhotel1.jpg", articleID = 20 });
                db.IMAGES.Add(new IMAGE() { imageSource = "Rexhotel2.jpg", articleID = 20 });
                db.SaveChanges();
            }
        }
    }
}
