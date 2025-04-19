from fastapi import APIRouter
import os, sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "../")))
from models.User import User
# from schemas.accountSchema import UserProfileRequest
from core.connect import create_connection

accountRouter = APIRouter()
print("Router loaded")


@accountRouter.post('/sign-in')
def sign_in():
    try:

        user = User()

        return {
            "Response": True,
            "data": {
                "user": ""
            }
        }



    except Exception as e:
        return {
            "Error": e
        }


@accountRouter.get("/profile")
def get_profile():
    user = User()
    sample = user.getUserProfileByID(1)
    return sample


    