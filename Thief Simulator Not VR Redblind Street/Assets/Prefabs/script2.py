import os
print("---------------------------------")
def search_and_print_values(filename):
    global totalvalue
    totalvalue = 0
    try:
        with open(filename, 'r') as file:
            content = file.read()
            start_idx = 0
            values = []

            while True:
                mass_start = content.find("mass:", start_idx)
                if mass_start == -1:
                    break

                value_start = content.find("value:", mass_start)
                if value_start == -1:
                    break

                name_start = content.find("name:", value_start)
                if name_start == -1:
                    break

                value_end = content.find("\n", value_start)
                name_end = content.find("\n", name_start)
                if value_end == -1 or name_end == -1:
                    break

                value_line = content[value_start:value_end]
                name_line = content[name_start:name_end]

                value = float(value_line.split(":")[1].strip())
                name = name_line.split(":")[1].strip()
                totalvalue = totalvalue + int(value)

                values.append((value, name))

                start_idx = name_end


            values.sort(reverse=True)

            for value, name in values:
                print(f"{name}: {int(value)}")

    except FileNotFoundError:
        print("File not found:", filename)
    except Exception as e:
        print("An error occurred:", e)
    totalvalues.append(totalvalue)
    print("The total value is:", totalvalue)

# List of filenames
file_names = [filename for filename in os.listdir() if filename.endswith(".prefab")]
totalvalues = []

for filename in file_names:
    print("Opening",filename)
    search_and_print_values(filename)
    print("---------------------------------")  # Separating lines between files
##########
combined_list = list(zip(totalvalues, file_names))

def ordinal_number(number):
    if 10 <= number % 100 <= 20:
        suffix = 'th'
    else:
        suffix = {1: 'st', 2: 'nd', 3: 'rd'}.get(number % 10, 'th')

    return str(number) + suffix

# Sort the list of tuples based on the values in Al
combined_list.sort(key=lambda x: x[0], reverse=True)

# Extract the sorted values for both Al and Bl
sorted_Al = [item[0] for item in combined_list]
sorted_Bl = [item[1] for item in combined_list]

for counter in range(len(sorted_Al)):
    courtner = counter + 1
    print(sorted_Bl[counter].rstrip("Stealables.prefab"), "is", ordinal_number(courtner), "with £" + str(sorted_Al[counter]))
print("The total value is £"+str(sum(totalvalues)))

