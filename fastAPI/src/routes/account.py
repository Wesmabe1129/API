from fastapi import APIRouter
import os, sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "../")))
from models.User import User

from core.connect import create_connection

accountRouter = APIRouter()
print("Router loaded")


@accountRouter.post('/sign-in')
def signIn():
    try:

        user = User()

    except Exception as e:
        return {
            "Error": e
        }


@accountRouter.get("/profile")
def get_profile():
    user = User()
    sample = user.create("wilson", "esmabe", "asd")
    return sample


    