// Задание 2: Вариант - 9
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

// Создание списка чётных чисел
let rec Create_List n =
    if n = 0 then
        []
    else
        let digit = abs n % 10
        let remains = Create_List (abs n / 10)
        if digit % 2 = 0 then
            digit :: remains // Добавляем цифру в начало списка
        else
            remains

[<EntryPoint>]
let main args = 
    printfn "Введите число: "
    let quantity = Check_quantity()
    printf "Получившийся список: %A" (Create_List quantity)
    0