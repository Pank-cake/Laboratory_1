// Задание 1: Вариант - 9
open System; 

// Проверка на корректность числа
let rec Check_quantity() =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)
    if succes && n > 0  then
       n
    else
        printfn "Ошибка: Введенное число должно быть натуральным. Введите другое число: "
        Check_quantity()
       
// Создание списка
let Create_List quantity =
    [
        for i in 1..quantity do
            printfn "Введите число %i: " i
            let number = Check_quantity()
            if number % 2 = 0 then 
               yield 1 // Запись в список при чётном числе
            else 
               yield 0 // Запись в список при нечётном числе
    ]

[<EntryPoint>]
let main args = 
    printfn "Введите количество чисел, которое будет введено: "
    let quantity = Check_quantity()
    printf "Получившийся список: %A" (Create_List quantity)
    0