from django import forms
from .models import Urun

class UrunForm(forms.ModelForm):
    class Meta:
        model=Urun
        fields=["title","content","bisiklet_image","medicine","brand","rim","gear","price","gender"]

class DeneForm(forms.Form):
   tikla=forms.BooleanField(required=False)