Create Table Weapons(
WeaponId int identity not null Primary Key,
WeaponName nvarchar(1000) not null,
WeaponType nvarchar(250) null,
)

Create Table WeaponAttributes(
AttributeId int identity not null Primary Key,
AttributeName nvarchar(1000) not null,
AttributeWeaponType nvarchar(250) null,
WeaponId int null
)


insert into Weapons values('Wooden Sword', 'Sword')
insert into Weapons values('Squirt Gun', null)
insert into Weapons values('Air Gun', 'Gun')
insert into Weapons values('Plastic Rake', 'Rake')
insert into Weapons values('Wooden Mallet',  null)
insert into Weapons values('Stringy Spatula',  'Kitchen Utensil')

insert into WeaponAttributes values ('Awkward', 'Sword', 1)
insert into WeaponAttributes values ('Cheap', null, 2)
insert into WeaponAttributes values ('Weak', 'Gun', 3)
insert into WeaponAttributes values ('Squeeky', 'Rake', 4)
insert into WeaponAttributes values ('Offensive', null, 5)
insert into WeaponAttributes values ('Annoying', 'Kitchen Utensil', null)