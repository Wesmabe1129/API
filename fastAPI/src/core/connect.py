import subprocess, os, mysql.connector
from dotenv import load_dotenv

load_dotenv()

cursor = None
connection = None

DB_HOST = os.getenv("DB_HOST")
DB_PORT = int(os.getenv("DB_PORT"))
DB_USER = os.getenv("DB_USER")
DB_PASS = os.getenv("DB_PASS")
DB_NAME = os.getenv("DB_NAME")



def create_connection():
    try:
        connection = mysql.connector.connect(
            host=DB_HOST,
            port=DB_PORT,
            user=DB_USER,
            password=DB_PASS,
            database=DB_NAME
        )


        # cursor = connection.cursor(dictionary=True)
        return connection
        # cursor.execute("SHOW DATABASES")
        # for db in cursor:
        #     print(db)
        # displaySelectQuery(cursor, "user")

    except mysql.connector.Error as err:
        print(f"Error: {err}")


    # finally:
    #     if cursor:
    #         cursor.close()
    #     if connection:
    #         connection.close()

    


# if __name__=="__main__":
#     create_connection()











# def get_container_ip(container_name):
#     try:
#         result = subprocess.check_output(
#             ['docker', 'inspect', '-f', '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}', container_name],
#             stderr=subprocess.STDOUT
#         )
#         return result.decode('utf-8').strip()
#     except subprocess.CalledProcessError as e:
#         print(f"Error retrieving IP: {e.output.decode()}")
#         return None

# container_ip = get_container_ip("mysql_master")


# def displaySelectQuery(executor, table):

#     executor.execute(f"SELECT * FROM {table}")
#     user = executor.fetchone()

#     print(user["id"])

#     print("\nUser:")
#     executor.execute(f"SELECT * FROM {table}")

#     for row in executor.fetchall():
#         print(row["password"])

    
# def execute_modify_query(query, params=None):
#     try:
#         connection = create_connection()
#         if connection:
#             cursor = connection.cursor()
#             cursor.execute(query, params or ())
#             connection.commit()  # Commit changes for INSERT, UPDATE, DELETE
#             print(f"Query executed successfully: {query}")
#             return cursor.rowcount  # Return number of affected rows
#     except mysql.connector.Error as err:
#         print(f"Error executing MODIFY query: {err}")
#     finally:
#         if cursor:
#             cursor.close()
#         if connection:
#             connection.close()
#     return 0
