from fastapi import APIRouter
import os, sys
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "../")))

from controllers.accountController import AccountController

accountRouter = APIRouter()
account = AccountController()

accountRouter.post("/login")(account.login)
accountRouter.post("/sign-up")(account.create)