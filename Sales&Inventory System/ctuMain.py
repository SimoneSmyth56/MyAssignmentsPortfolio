from ctuStock import Stock
from ctuInventory import Inventory


shop1 = Stock("Default", "Default", 0, 0, 0)
shop2 = Stock("Default", "Default", 0, 0, 0)
shop3 = Stock("Default", "Default", 0, 0, 0)
shop4 = Stock("Default", "Default", 0, 0, 0)


item1 = Inventory("Item 1", "Modem", 15, 500.56)
item2 = Inventory("Item 2", "Keyboard", 20, 250.78)
item3 = Inventory("Item 3", "CPU", 5, 700.99)
item4 = Inventory("Item 4", "Power Cable", 10, 300.50)

inventory_list = [item1, item2, item3, item4]


def available_stock():
    for x in inventory_list:
        print(x.itemNumber, "  ", x.equipment, " ", x.quantity, " ZAR", x.cost)


def main_menu():
    print("""Welcome to CTU Technologies
1. Shop Management
2. Sales
3. Returns
4. Stock
99. Exit""")


def shop_management_menu():
    print("""Shop Management
    1. Change shop name
    2. Change shop location
    3. Display current shops
    4. Display all shop information
    0. Back""")


def display_all_information():
    print("*** Shop 1 ***")
    print("Shop Name:", shop1.shopName)
    print("Shop Location:", shop1.shopLocation)
    print("Number of customers:", shop1.customers)
    print("Current sales:", shop1.sales)
    print("Returns:", shop1.returns)
    print("_____________________________")
    print("*** Shop 2 ***")
    print("Shop Name:", shop2.shopName)
    print("Shop Location:", shop2.shopLocation)
    print("Number of customers:", shop2.customers)
    print("Current sales:", shop2.sales)
    print("Returns:", shop2.returns)
    print("_____________________________")
    print("*** Shop 3 ***")
    print("Shop Name:", shop3.shopName)
    print("Shop Location:", shop3.shopLocation)
    print("Number of customers:", shop3.customers)
    print("Current sales:", shop3.sales)
    print("Returns:", shop3.returns)
    print("_____________________________")
    print("*** Shop 4 ***")
    print("Shop Name:", shop4.shopName)
    print("Shop Location:", shop4.shopLocation)
    print("Number of customers:", shop4.customers)
    print("Current sales:", shop4.sales)
    print("Returns:", shop4.returns)


def invalid_response():
    print("That is not a valid response, please try again")


def log_return_menu():
    print("""Log a return:
    1. Modem
    2. Keyboard
    3. CPU
    4. Power Cable""")


def stock_menu():
    print("""
1. Display Stock
2. Add Stock
0. Back""")


while True:
    main_menu()

    main_menu_option = int(input("Select an option or 99 to exit: "))
    print(main_menu_option)

    if main_menu_option == 1:
        print(shop_management_menu())

        shop_management_option = int(input("Select an option: "))
        print(shop_management_option)

        if shop_management_option == 1:
            print("Change Shop name")
            print("Select Shop")
            print("1.", shop1.shopName)
            print("2.", shop2.shopName)
            print("3.", shop3.shopName)
            print("4.", shop4.shopName)
            print("0. Back")

            shop_name_option = int(input("Select an option: "))  # user needs to select between number 1-4

            if shop_name_option == 1:
                change_shopName1 = input("Type the new Shop name: ")  # new shop to replace the "Default" shop name
                shop1.shopName = change_shopName1
                print("Shop name was successfully changed to", shop1.shopName)

            elif shop_name_option == 2:
                change_shopName2 = input("Type the new Shop name: ")
                shop2.shopName = change_shopName2
                print("Shop name was successfully changed to", shop2.shopName)

            elif shop_name_option == 3:
                change_shopName3 = input("Type the new Shop name: ")
                shop3.shopName = change_shopName3
                print("Shop name was successfully changed to", shop3.shopName)

            elif shop_name_option == 4:
                change_shopName4 = input("Type the new Shop name: ")
                shop4.shopName = change_shopName4
                print("Shop name was successfully changed to", shop3.shopName)

            if shop_name_option == 0:
                main_menu()

            if shop_name_option >= 5:
                invalid_response()  # if response nr is bigger than 5, error will display

        if shop_management_option == 2:
            print("Change Shop location")
            print("Select Shop")
            print("1.", shop1.shopLocation)
            print("2.", shop2.shopLocation)
            print("3.", shop3.shopLocation)
            print("4.", shop4.shopLocation)
            print("0. Back")

            shop_location_option = int(input("Select an option: "))  # type location from available location list
            available_locations = ["Free State", "Gauteng", "KZN", "Limpopo"]

            if shop_location_option == 1:
                change_location1 = input("Enter a location - Free State, Gauteng, KZN, Limpopo: ")
                if change_location1 in available_locations:  # new location to replace the "Default" location
                    shop1.shopLocation = change_location1
                    print("Shop name was successfully changed to", shop1.shopLocation)
                else:
                    invalid_response()  # if response is not from list, error will display

            elif shop_location_option == 2:
                change_location2 = input("Enter a location - Free State, Gauteng, KZN, Limpopo: ")
                if change_location2 in available_locations:
                    shop2.shopLocation = change_location2
                    print("Shop name was successfully changed to", shop2.shopLocation)
                else:
                    invalid_response()

            elif shop_location_option == 3:
                change_location3 = input("Enter a location - Free State, Gauteng, KZN, Limpopo: ")
                if change_location3 in available_locations:
                    shop3.shopLocation = change_location3
                    print("Shop name was successfully changed to", shop3.shopLocation)
                else:
                    invalid_response()

            elif shop_location_option == 4:
                change_location4 = input("Enter a location - Free State, Gauteng, KZN, Limpopo: ")
                if change_location4 in available_locations:
                    shop4.shopLocation = change_location4
                    print("Shop name was successfully changed to", shop4.shopLocation)
                else:
                    invalid_response()

            if shop_location_option == 0:
                shop_management_menu()

            if shop_location_option >= 5:
                invalid_response()

        if shop_management_option == 3:
            print("Current Shops")
            print("1.", shop1.shopName, ",", shop1.shopLocation)
            print("2.", shop2.shopName, ",", shop2.shopLocation)
            print("3.", shop3.shopName, ",", shop3.shopLocation)
            print("4.", shop4.shopName, ",", shop4.shopLocation)

        if shop_management_option == 4:
            display_all_information()

        if shop_management_option >= 5:
            invalid_response()

    if main_menu_option == 2:
        print("This is our available stock")

        available_stock()

        buy_item = input("Select item number you would like to purchase: ")
        print(buy_item)

        buy_amount = int(input("Select amount you would like to purchase : "))
        print(buy_amount)

        buy_shop = input('Select from which shop you would like to purchase?  ')
        print(buy_shop)

        if buy_item == item1.itemNumber:
            item1.quantity -= buy_amount  # amount of items bought deducted from available stock

        if buy_item == item2.itemNumber:
            item2.quantity -= buy_amount

        if buy_item == item3.itemNumber:
            item3.quantity -= buy_amount

        if buy_item == item4.itemNumber:
            item4.quantity -= buy_amount

        if buy_shop == shop1.shopName:
            shop1.customers += 1  # customer count is added by increments of 1
            shop1.sales += buy_amount

        if buy_shop == shop2.shopName:
            shop2.customers += 1
            shop2.sales += buy_amount

        if buy_shop == shop3.shopName:
            shop3.customers += 1
            shop3.sales += buy_amount

        if buy_shop == shop2.shopName:
            shop4.customers += 1
            shop4.sales += buy_amount

    if main_menu_option == 3:
        available_stock()

        return_item = input("Select item number you would like to return: ")
        print(return_item)

        return_amount = int(input("Select amount you would like to return: "))
        print(return_amount)

        return_shop = input('Select to which shop you would like to return the product?  ')
        print(return_shop)

        if return_item == item1.itemNumber:
            item1.quantity += return_amount  # amount of items returned is added to available stock

        if return_item == item2.itemNumber:
            item2.quantity += return_amount

        if return_item == item3.itemNumber:
            item3.quantity += return_amount

        if return_item == item4.itemNumber:
            item4.quantity += return_amount

        if return_shop == shop1.shopName:
            shop1.sales -= return_amount
            shop1.returns += return_amount

        if return_shop == shop2.shopName:
            shop2.sales -= return_amount
            shop2.returns += return_amount

        if return_shop == shop3.shopName:
            shop3.sales -= return_amount
            shop3.returns += return_amount

        if return_shop == shop4.shopName:
            shop4.sales -= return_amount
            shop4.returns += return_amount

    if main_menu_option == 4:
        stock_menu()
        stock_menu_option = int(input("Select one of the following options: "))
        print(stock_menu_option)

        if stock_menu_option == 1:
            available_stock()

        if stock_menu_option == 2:
            add_item_number = input("Add the item number of the stock you want to add: ")
            print(add_item_number)

            add_item_type = input("Which item would you like to add to the stock? ")
            print(add_item_type)

            add_item_quantity = int(input("How many items do you want to add? "))
            print(add_item_quantity)

            add_item_price = float(input("What is the price of the item in (ZAR)? "))
            print(add_item_price)

            inventory_list.append(Inventory(add_item_number, add_item_type, add_item_quantity, add_item_price))

            print("Items have successfully been added")

        if stock_menu_option == 0:
            main_menu()

        elif stock_menu_option > 2:
            invalid_response()

    if main_menu_option == 99:
        break
