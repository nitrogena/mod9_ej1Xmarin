using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace TelefonoAndriod
{
	[Activity(Label = "TelefonoAndriod", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			EditText etNumero = FindViewById<EditText>(Resource.Id.txtNumero);
			Button btnTraducir = FindViewById<Button>(Resource.Id.btnTraducir);
			Button btnLlamar = FindViewById<Button>(Resource.Id.btnLlamar);

			btnLlamar.Enabled = false;

			string numeroTraducido = string.Empty;

			btnTraducir.Click += (object sender, EventArgs e) =>
			{
				numeroTraducido = Traductor.TraduceNumeroACadena(etNumero.Text);
				if (String.IsNullOrWhiteSpace(numeroTraducido))
				{
					btnLlamar.Text = "Llamar";
					btnLlamar.Enabled = false;
				}
				else {
					btnLlamar.Text = "Llamar " + numeroTraducido;
					btnLlamar.Enabled = true;
				}
			};

			btnLlamar.Click += (object sender, EventArgs e) =>
			{
				var ventanaLlamar = new AlertDialog.Builder(this);
				ventanaLlamar.SetMessage("Llamar a " + numeroTraducido +"?");
				ventanaLlamar.SetNeutralButton("Llamar", delegate {
					var llamadaIntent = new Intent(Intent.ActionCall);
					llamadaIntent.SetDat(Android.Net.Uri.Parse("tel: " + numeroTraducido));
					StartActivity(llamadaIntent);

				});

				ventanaLlamar.SetNegativeButton("Cancelar", delegate { });
				ventanaLlamar.Show();

					             

			};
		}
	}
}

