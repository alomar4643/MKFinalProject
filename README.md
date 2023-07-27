## Welcome to Mortal Kombat Db!

Introducing a dynamic CRUD Web API designed for storing data about fighting game characters found in _Mortal Kombat_. With this CRUD API, users gain the ability to effortlessly add new characters, modify and update existing ones, and even delete them entirely from the database. I encourage you to try adding your own characters and moves to the collection!

### Features
1. Application is a CRUD Web API.
2. Application is asynchronous.
3. Program queries the databse using Raw SQL.
4. Optional: SOLID principles comments where made througout the application. 

### Instructions
In order to successfully run this CRUD Web API the user will need to:

1. Initialize the databse, please run `donet ef database update` in the Developer PowerShell Terminal.
--
2. Find the Mortal Komabt db file created in your local folder inside your file explorer (C:\Users\ "*your username here*"\AppData\Local). The database will be empty, but feel free to use the character and move examples found in Table 1. 
--
3. Running the program will start an instance of Swagger in your web browser. There you can access the use of GET, POST, PUT, and DELETE sections. The program will **_not_** create a unique GUID when adding a new character. Feel free to use a [Free Online Guid Generator](https://guidgenerator.com/online-guid-generator.aspx/) when adding your own characters and moves.

### Table 1
**Characters**

    "id": "750c1676-49b2-4436-8575-77ab914213d3",
    "name": "Scorpion"
  
    "id": "b0141577-ef4f-4a14-a5fa-4fee5f64bee0",
    "name": "Kano"
  
    "id": "2fb1efcb-fd41-4177-8174-25b5fb0f61ab",
    "name": "Liu Kang"

**Moves**

_Scorpion_

    "id": "6b4b8153-215f-4a28-993c-b701c2889f6f",
    "name": "Spear",
    "description": "B,B,LP",
    "isFatality": false
  
    "id": "e8c2bfad-62ee-47cc-986e-89b12e99f96d",
    "name": "Fatality",
    "description": "Up, Up",
    "isFatality": true

_Kano_

    "id": "eca56503-6ed7-4d8d-90cd-06ab9ec67e6b",
    "name": "Kano- Spin Attack",
    "description": "F,D,B,Up,F",
    "isFatality": false


    "id": "5d63ce25-8f9e-4630-8b91-a264f850184d",
    "name": "Kano Fatality 1",
    "description": "B,D,F,LP",
    "isFatality": true


_Liu Kang_

    "id": "57f0a75b-a69f-4d07-b0ba-cc462c491dcf",
    "name": "Liu Kang- Fireball",
    "description": "F,F,HP",
    "isFatality": false

    "id": "d9ccc650-d24e-4899-9b8e-25f975f65650",
    "name": "Liu Kang- Fatality ",
    "description": "F,D,B,Up,F",
    "isFatality": true
  
#### Move Abbreviations
| Abbreviation  | Definition    |
| ------------- |:-------------:|
| B      | Back |
| F      | Forward      |
| D | Down     |
| Up     | Up     |
| HP | High Punch      |
| LK      | Low Kick     |
| HK | High Kick     |
| BL      | Block     |

_Thank you for using this Mortal Kombat Db API!_