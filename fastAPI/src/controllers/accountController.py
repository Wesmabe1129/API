from fastapi import Request, Depends
import os, sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "../")))

from schemas.createAccount import CreateAccountRequest

class AccountController:
    
    def __init__(self):
        pass


    async def login(self, request: Request):
        body = await request.json()
        print(body["id"], body["username"])

        return {"message": "Successfully Login", "data": body}

    async def create(self, request: Request):
        body = await request.json()

        print(body["id"], body["username"])
        
        return {
            "message": "Successfully Create Account",
            "data": {
                "user_id": body["id"],
                "username": body["username"]
            }
            }

    async def profile(self, request: Request):
        return {"message": "Get Profile"}
