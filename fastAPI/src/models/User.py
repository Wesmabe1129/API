import os
import sys


sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "../")))
# sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "../../")))

from core.connect import create_connection
from utils.hash import encrypt_password





# conn = create_connection()

# cursor = conn.cursor(dictionary=True)

# cursor.execute("SELECT * FROM user")

# for user in cursor.fetchall():
#     print(user)


class User:

    
    @staticmethod
    def displaySelectQuery(executor, table):

        executor.execute(f"SELECT * FROM {table}")
        user = executor.fetchone()

        print(user["id"])

        print("\nUser:")
        executor.execute(f"SELECT * FROM {table}")

        for row in executor.fetchall():
            print(row["password"])
    
    @staticmethod
    def create(username, email, password):
        
        try:
            if not username or not email or not password:
                return {
                    "Response": "False",
                    "message": "Invalid Input"
                }
            
            db = create_connection()
            cur = db.cursor(dictionary=True)

            cur.execute("SELECT * FROM user")

            user = cur.fetchone()


            return {
                "Response": "True",
                "data": {
                    "id": user["id"],
                    "username": user["username"]
                }
            }

            # for row in cur.fetchall():
            #     return {
            #         "Response": "True",
            #         "data": {
            #             "id": row["id"],
            #             "username": row["username"],
            #             "email": row["email"],
            #         }
            #     }

        except Exception as e:
            return {
                "Error": e
            }

        
        

    

    @staticmethod
    def getUserProfileByID(user_id: int):

        

        try:
            if not user_id:
                return {
                    "Response": "False",
                    "message": "No user found!"
                }
            
            db = create_connection()
            cur = db.cursor(dictionary=True)

            cur.execute("SELECT * FROM user")

            user = cur.fetchone()
            return {
                "Response": "True",
                "data": {
                    "id": user["id"],
                    "username": user["username"]
                }
            }

        except Exception as e:
            return {
                "Response": False,
                "Error": e
            }

    

    



