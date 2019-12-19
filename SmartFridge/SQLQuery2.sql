select * from Recepies
	where In_Fridge = 'True'
		order by Name;
/*dishes in the fridge ordered by name*/

select * from Recepies
	where Category = 1
		order by Name;
/*recepies with exact category ordered by name*/

select * from Products
	where In_Fridge = 'True'
		order by name;
/*products in the fridge ordered by name*/

insert into Products (name, category, proteins, Fats, Carbohydrates, Calories, ExDate, Description)
values (N'Лимон', 2, 0.9, 0.1, 3, 34, 10, N'растение; вид рода Цитрус подтрибы Цитрусовые семейства Рутовые.')



