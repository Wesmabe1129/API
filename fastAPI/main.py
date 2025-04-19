from fastapi import FastAPI
import uvicorn


from src.routes.account import accountRouter
from src.routes.homeRoutes import homeRouter



app = FastAPI()
app.include_router(router=accountRouter, prefix="/v1", tags=["DB Connection"])

app.include_router(router=homeRouter, prefix="/v1", tags=["HOME"])





# if __name__=="__main__":
    