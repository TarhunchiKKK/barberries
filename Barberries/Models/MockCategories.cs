namespace Barberries.Models {
	public class MockCategories {

		public List<Category> GetCategories() {

			// main categories
			Category books = new Category {
				Picture = "https://www.holisticwellnesspractice.com/wp-content/uploads/2021/05/Book-Summary-scaled.jpeg",
				Name = "Books",
				Id = 1
			};
			Category clothes = new Category {
				Picture = "https://btkorzina.ru/wp-content/uploads/2021/02/60322ba5c0a71-scaled.jpg",
				Name = "Clothes", 
				Id = 2
			};
			Category electronics = new Category {
				Picture = "https://www.optometrystudents.com/wp-content/uploads/2018/09/Technology_Phone_Tablet_AdobeStock_61668339.jpeg",
				Name = "Electronics",
				Id = 3
			};
			Category furnitures = new Category {
				Picture = "https://camel-kler.by/wp-content/uploads/2018/11/ТН0400019_7-1024x658.jpg",
				Name = "Furnitures",
				Id = 4
			};
			Category zooProducts = new Category {
				Picture = "https://ae01.alicdn.com/kf/H7c2bb94106624623aacc25212be3a48e4.jpg",
				Name = "Zoo-products",
				Id = 5
			};

			// books
			Category educationBooks = new Category {
				Picture = "https://naked-science.ru/wp-content/uploads/2022/03/Nauka-zastavka.jpg",
				Name = "Education books",
				Parent = books,
				Id = 6
			};
			Category historyBooks = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=12c7a2675196b2381ec96d965ac581e7873ca10e-8483391-images-thumbs&n=13",
				Name = "History books",
				Parent = books,
				Id = 7
			};
			Category religiosBooks = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=6a9104c8f4e5e977286d027c82361b9a74474e3c-7683610-images-thumbs&n=13",
				Name = "Religios books",
				Parent = books,
				Id = 8
			};
			Category selfDevelopmentBooks = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=db836d3b0ee316a0af69ef5991ca582a3b74b473-6392895-images-thumbs&n=13",
				Name = "Selfdevelopment books",
				Parent = books,
				Id = 9
			};

			// clothes
			Category dresses = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=ceddc445292c14177d3d298bfbd4f724-5177926-images-thumbs&n=13",
				Name = "Dresses",
				Parent = clothes,
				Id = 10
			};
			Category hoodies = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=4b04bf561296b0dc620ecd597be645ef443840aa-5509039-images-thumbs&n=13",
				Name = "Hoodies",
				Parent = clothes,
				Id = 11
			};
			Category jeans = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=d573b0123f6a21bfd111e9c80bb046987fcb4697-9147461-images-thumbs&n=13",
				Name = "Jeans",
				Parent = clothes,
				Id = 12
			};
			Category shirts = new Category {
				Picture = "https://ae01.alicdn.com/kf/HTB1ATPeaC3PL1JjSZPcq6AQgpXau/MIACAWOR-Plaid-Shirts-Men-Spring-Long-Sleeve-Camisa-Masculina-Casual-Shirt-Slim-Fit-Men-Dress-Shirt.jpg",
				Name = "Shirts",
				Parent = clothes,
				Id = 13
			};
			Category sweatshirts = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=18e58e6109f8ebc92b17013058f39eb66f54a0d0-7882711-images-thumbs&n=13",
				Name = "Sweatshirts",
				Parent = clothes,
				Id = 14
			};
			Category tShirts = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=ff0786d88f5068aaf7bd8729df3ab25f901302a3-8710005-images-thumbs&n=13",
				Name = "T-shirts",
				Parent = clothes,
				Id = 15
			};

			// electronics
			Category laptops = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=19d19ba3259e17d703e21c2ac8d5541433f383fd-7547218-images-thumbs&n=13",
				Name = "Laptops",
				Parent = electronics,
				Id = 16
			};
			Category smartPhones = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=5c0359d657346434701d97160e3f7316-5244405-images-thumbs&n=13",
				Name = "Smartphones",
				Parent = electronics,
				Id = 17
			};
			Category smartWatches = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=9c98666d137123beff3bfb1e84d79adf-4080501-images-thumbs&n=13",
				Name = "Smart watches",
				Parent = electronics,
				Id = 18
			};
			Category tablets = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=afe9dcb9889843009f14e4db7464ac8795a7bb83-6177852-images-thumbs&n=13",
				Name = "Tablets",
				Parent = electronics,
				Id = 19
			};

			// furnitures
			Category beds = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=3b2b9ee909910305b8ba1298aa3b9c4e8b7207d2-9217732-images-thumbs&n=13",
				Name = "Beds",
				Parent = furnitures,
				Id = 20
			};
			Category refrigerators = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=ee6e9f6d0b092ca0fc0c8e5eb8bbd28197805114-8185197-images-thumbs&n=13",
				Name = "Refrigerators",
				Parent = furnitures,
				Id = 21
			};
			Category tables = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=3564dce28e0fdb7823c62a13b98343c8abbd3bd1-8438571-images-thumbs&n=13",
				Name = "Tabes",
				Parent = furnitures,
				Id = 22
			};
			Category wardrobes = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=9e7a6fde13f5ab4a9e5a85f1b556795cfae28da2-9181373-images-thumbs&n=13",
				Name = "Wardrobes",
				Parent = furnitures,
				Id = 23
			};

			// zoo-products
			Category animalClothes = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=f4d35a2ca74f60187f93d59acc86a3fc952e67ce-8750921-images-thumbs&n=13",
				Name = "Animal clothes",
				Parent = zooProducts,
				Id = 24
			};
			Category animalFeed = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=3be260d0110d0ce14244a406e5fcc33dd0d6853e-8257574-images-thumbs&n=13",
				Name = "Animal feed",
				Parent = zooProducts,
				Id = 25
			};
			Category animalToys = new Category {
				Picture = "https://avatars.mds.yandex.net/i?id=581cf2ff98c47d0fc246f55766df08c52ad42241-9137660-images-thumbs&n=13",
				Name = "Animal toys",
				Parent = zooProducts,
				Id = 26
			};

			// return all categories
			return new List<Category>() {
				books, clothes, electronics, furnitures, zooProducts,
				educationBooks, historyBooks, religiosBooks, selfDevelopmentBooks,
				dresses, hoodies, jeans, shirts, sweatshirts, tShirts,
				laptops, smartPhones, smartWatches, tablets,
				beds, refrigerators, tables, wardrobes,
				animalClothes, animalFeed, animalToys
			};
		}
	}
}
