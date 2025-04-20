from fastapi import APIRouter
import os, sys


sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "./")))

from accountRoutes import accountRouter
from homeRoutes import homeRouter

v1 = APIRouter()

v1.include_router(router=accountRouter, prefix="/account", tags=["ACCOUNT ROUTES"])

v1.include_router(router=homeRouter, prefix="", tags=["HOME"])